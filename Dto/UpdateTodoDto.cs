using TodoApi.Enums;

namespace TodoApi.Dto
{
    public class UpdateTodoDto
    {
        public string NameTodo { get; set; }
        public string Description { get; set; }
        public TodoStatus Status { get; set; }
    }
}