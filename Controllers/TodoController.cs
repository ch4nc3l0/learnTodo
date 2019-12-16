using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreTodo.Models;

// Controllers are the functionallity of an application

namespace AspNetCoreTodo.Controllers{
    public class TodoController : Controller{

        public IActionResult Index(){
            // Get item from DB

            // Assign item to model

            // Render view using model
            return View();
        }

    }
}