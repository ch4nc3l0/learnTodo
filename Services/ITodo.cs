using AspNetCoreTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Services // This interface will be interacting with the database || Not being handled by the controller
{
    interface ITodo
    {
        Task<Todo> GetTodo(); // Defining an async method to get todos from the database
    }
}
