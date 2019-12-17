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

    }
}
