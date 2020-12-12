namespace TodoAPI_2.Todos
{
    public class Todo
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsChecked { get; set; }
        public Todo(string text)
        {
            Content = text;
            IsChecked = false;
        }
        public Todo()
        {

        }
    }
}