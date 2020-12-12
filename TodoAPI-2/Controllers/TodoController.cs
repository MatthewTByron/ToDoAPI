using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI_2.Todos;

namespace TodoAPI_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private ITodoService _todoService { get; set; }

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await _todoService.GetAllTodos();
            return View(model);
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _todoService.GetAllTodos();
        }
        [HttpGet("{id}")]
        public async Task<Todo> GetTodo(int id)
        {
            return await _todoService.GetTodo(id);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateTodo(Todo todo)
        {
            if (await _todoService.UpdateTodo(todo))
            {
                return Ok(todo);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<Todo> InsertTodo(string text)
        {
            return await _todoService.InsertTodo(text);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTodo(int Id)
        {
            await _todoService.DeleteTodo(Id);
            return Ok();
        }
    }
}