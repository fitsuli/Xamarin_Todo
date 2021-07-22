namespace Todo.Models
{
    public class TodoItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
        public bool Undone => !Done;
    }
}
