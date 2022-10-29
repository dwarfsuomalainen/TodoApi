namespace TodoApi.Models
{
    public class User : Base
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Todo> Todos { get; set; } = new HashSet<Todo>();
    }
}