using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI_2.Todos
{
    public class TodoService : ITodoService
    {
        private ITodoRepository _todoRepository { get; set; }

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _todoRepository.GetAllTodos();
        }

        public async Task<Todo> GetTodo(int id)
        {
            return await _todoRepository.GetTodo(id);
        }

        public async Task<bool> UpdateTodo(Todo todo)
        {
            return await _todoRepository.UpdateTodo(todo);
        }

        public async Task<Todo> InsertTodo(string text)
        {
            var todo = new Todo(text);
            return await _todoRepository.InsertTodo(todo);
        }

        public async Task DeleteTodo(int Id)
        {
            await _todoRepository.DeleteTodo(Id);
        }
    }
}
