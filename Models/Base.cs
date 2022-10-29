namespace TodoApi.Models
{
    public abstract class Base
    {
        public int Id { get; set; }
        public DateTime TodoCreated { get; set; } = DateTime.UtcNow;
        public DateTime TodoUpdated { get; set; } = DateTime.UtcNow;

    }
}