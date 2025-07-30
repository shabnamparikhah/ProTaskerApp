using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProTasker.Data;
using ProTasker.Models;
using TaskStatusEnum = ProTasker.Models.TaskStatus;

namespace ProTasker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/taskapi
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _context.TaskItems
                                      .OrderByDescending(t => t.Id)
                                      .ToListAsync();
            return Ok(tasks);
        }

        // GET: api/taskapi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        // POST: api/taskapi
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
                return BadRequest("Title is required");

            task.Status = TaskStatusEnum.Todo;
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // PUT: api/taskapi/5/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return NotFound();

            if (!Enum.TryParse(status, out TaskStatusEnum newStatus))
                return BadRequest("Invalid status");

            task.Status = newStatus;
            _context.TaskItems.Update(task);
            await _context.SaveChangesAsync();

            return Ok(task);
        }

        // DELETE: api/taskapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return NotFound();

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
