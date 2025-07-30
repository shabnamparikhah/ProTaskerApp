using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProTasker.Data;
using ProTasker.Models;
using TaskStatusEnum = ProTasker.Models.TaskStatus;

namespace ProTasker.Controllers
{
    public class TaskItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Kanban(int projectId = 1)
        {
            var tasks = await _context.TaskItems
                                      .Where(t => t.ProjectId == projectId)
                                      .ToListAsync();

            var viewModel = new KanbanViewModel
            {
                ProjectId = projectId,
                Todo = tasks.Where(t => t.Status == TaskStatusEnum.Todo).ToList(),
                InProgress = tasks.Where(t => t.Status == TaskStatusEnum.InProgress).ToList(),
                Done = tasks.Where(t => t.Status == TaskStatusEnum.Done).ToList()
            };

            return View(viewModel);
        }

        [Authorize] // فقط وقتی لاگین باشه می‌تونه Task بسازه
        [HttpPost]
        public async Task<IActionResult> Create(int projectId, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("Title cannot be empty.");

            var task = new TaskItem
            {
                ProjectId = projectId,
                Title = title,
                Status = TaskStatusEnum.Todo
            };

            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();

            return Json(new { id = task.Id, title = task.Title, status = task.Status.ToString() });
        }

        [Authorize] // فقط وقتی لاگین باشه می‌تونه Status رو تغییر بده
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return NotFound();

            if (Enum.TryParse(status, out TaskStatusEnum newStatus))
            {
                task.Status = newStatus;
                _context.TaskItems.Update(task);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest("Invalid status");
        }
    }
}
