using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;

// Controllers are the functionallity of an application

namespace AspNetCoreTodo.Controllers{
    public class TodoController : Controller{

        private readonly ITodoService _todoService; // Private var to hold referance to TodoService

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }


        public async Task<IActionResult> Index(){
            // Get item from DB
            var todos = await _todoService.GetTodo();

            // Assign item to model
            var model = new TodoViewModel()
            {
                Todos = todos
            };

            // Render view using model
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTodo(Todo newTodo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoService.AddTodo(newTodo);
            if (!successful)
            {
                return BadRequest("Could not add item");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoService.MarkDone(id);
            if (!successful)
            {
                return BadRequest("Could not mark todo done");
            }
            return RedirectToAction("Index");
        }
    }
}