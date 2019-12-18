using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Services // This interface will be interacting with the database || Not being handled by the controller
{
    public interface ITodoService
    {
        Task<Todo[]> GetTodo( IdentityUser user); // Defining an async method to get todos from the database

        Task<bool> AddTodo(Todo newTodo, IdentityUser user);

        Task<bool> MarkDone(Guid id, IdentityUser user);
    }
}
