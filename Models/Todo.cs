using TodoApi.Enums;

namespace TodoApi.Models
{
    public class Todo : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public TodoStatus Status { get; set; } = TodoStatus.NotStarted;
        public virtual User? User { get; set; }

    }
}