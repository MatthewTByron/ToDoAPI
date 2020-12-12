using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoAPI_2.Todos
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodo(int Id);
        Task<bool> UpdateTodo(Todo todo);
        Task<Todo> InsertTodo(Todo todo);
        Task DeleteTodo(int Id);

    }
}