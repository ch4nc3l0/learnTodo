using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Services
{
    public class TodoService : ITodoService
    {
        // Declare a var
        private readonly ApplicationDbContext _context;

        // Set equal to context
        public TodoService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // Return var with data
        public async Task<Todo[]> GetTodo()
        {
            return await _context.Todos
                .Where(x => x.IsDone == false)
                .ToArrayAsync();
        }

        public async Task<bool> AddTodo(Todo newTodo)
        {
            newTodo.Id = Guid.NewGuid();
            newTodo.IsDone = false;
            newTodo.DueAt = DateTimeOffset.Now.AddDays(2);

            _context.Todos.Add(newTodo);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> MarkDone(Guid id)
        {
            var todo = await _context.Todos
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (todo == null)
            {
                return false;
            }

            todo.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

    }
}
