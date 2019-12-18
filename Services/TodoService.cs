using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;
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
        public async Task<Todo[]> GetTodo(IdentityUser user)
        {
            return await _context.Todos
                .Where(x => x.IsDone == false && x.UserId == user.Id)
                .ToArrayAsync();
        }

        public async Task<bool> AddTodo(Todo newTodo, IdentityUser user)
        {
            newTodo.Id = Guid.NewGuid();
            newTodo.IsDone = false;
            newTodo.DueAt = DateTimeOffset.Now.AddDays(2);
            newTodo.UserId = user.Id;

            _context.Todos.Add(newTodo);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> MarkDone(Guid id, IdentityUser user)
        {
            var todo = await _context.Todos
                .Where(x => x.Id == id && x.UserId == user.Id)
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
