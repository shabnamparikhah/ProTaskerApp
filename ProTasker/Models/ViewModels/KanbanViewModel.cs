using System.Collections.Generic;

namespace ProTasker.Models
{
    public class KanbanViewModel
    {
        public int ProjectId { get; set; }  // 

        public List<TaskItem> Todo { get; set; } = new();
        public List<TaskItem> InProgress { get; set; } = new();
        public List<TaskItem> Done { get; set; } = new();
    }
}
