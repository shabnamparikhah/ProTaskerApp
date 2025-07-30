using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProTasker.Data;
using ProTasker.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProTasker.Controllers
{
    public class KanbanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KanbanController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int projectId)
        {
            var tasks = await _context.TaskItems
                                      .Include(t => t.Project)
                                      .Where(t => t.ProjectId == projectId) // فقط تسک‌های همین پروژه
                                      .ToListAsync();

            var viewModel = new KanbanViewModel
            {
                ProjectId = projectId,
                Todo = tasks.Where(t => t.Status == ProTasker.Models.TaskStatus.Todo).ToList(),
                InProgress = tasks.Where(t => t.Status == ProTasker.Models.TaskStatus.InProgress).ToList(),
                Done = tasks.Where(t => t.Status == ProTasker.Models.TaskStatus.Done).ToList()
            };

            return View(viewModel);
        }

    }
}
