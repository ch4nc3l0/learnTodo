using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

// Controllers are the functionallity of an application

namespace AspNetCoreTodo.Controllers{

    [Authorize]
    public class TodoController : Controller{

        private readonly ITodoService _todoService; // Private var to hold referance to TodoService
        private readonly UserManager<IdentityUser> _userManager;

        public TodoController(ITodoService todoService , UserManager<IdentityUser> userManager)
        {
            _todoService = todoService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index(){

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }

            // Get item from DB
            var todos = await _todoService.GetTodo(currentUser);

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

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }

            var successful = await _todoService.AddTodo(newTodo, currentUser);
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

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }

            var successful = await _todoService.MarkDone(id, currentUser);
            if (!successful)
            {
                return BadRequest("Could not mark todo done");
            }
            return RedirectToAction("Index");
        }
    }
}