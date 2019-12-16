using AspNetCoreTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoService
    {
        public Task<Todo[]> GetTodo()
        {
            // Fake list of todo no db yet
            var todo1 = new Todo
            {
                Title = "Get the kids",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };
            var todo2 = new Todo
            {
                Title = "Build the best app",
                DueAt = DateTimeOffset.Now.AddMinutes(1)
            };

            return Task.FromResult(new[] { todo1, todo2 });
        }
    }
}
