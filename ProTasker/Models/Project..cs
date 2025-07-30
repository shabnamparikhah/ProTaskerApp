using System.ComponentModel.DataAnnotations;

namespace ProTasker.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public List<TaskItem> Tasks { get; set; } = new();
    }
}