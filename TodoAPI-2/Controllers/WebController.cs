using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoAPI_2.Todos;

namespace TodoAPI_2.Controllers
{
    [Route("[controller]")]
    public class WebController : Controller
    {
        private ITodoService _todoService { get; set; }

        public WebController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await _todoService.GetAllTodos();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddTodo([FromForm]string newText)
        {
            var result = await _todoService.InsertTodo(newText);
            var model = await _todoService.GetAllTodos();
            return View("Index", model);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> DeleteTodo([FromRoute]int Id)
        {
            await _todoService.DeleteTodo(Id);
            var model = await _todoService.GetAllTodos();
            return View("Index", model);
        }
    }
}