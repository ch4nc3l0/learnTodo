// Create a viewmodel for todo to be able to pass the full array of todos to the view

namespace AspNetCoreTodo.Models{
    public class TodoViewModel{
        public Todo[] Items { get; set; }
    }
}