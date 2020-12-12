using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI_2.Todos;

namespace TodoAPI_2.Tests
{
    internal class MockTodoRepository : ITodoRepository
    {
        public List<Todo> Todos { get; }

        public MockTodoRepository()
        {
            Todos = new List<Todo>
            {
                new Todo() { Id = 1, Content = "first todo", IsChecked = false },
                new Todo() { Id = 2, Content = "second todo", IsChecked = false },
                new Todo() { Id = 3, Content = "third todo", IsChecked = false }
            };
        }
        public IEnumerable<Todo> GetAllTodos()
        {
            return Todos;
        }

        public Todo GetTodo(int id)
        {
            var result = new Todo();
            foreach (var item in Todos)
            {
                if (item.Id == id)
                {
                    result = item;
                }
            }
            return result;
        }

        Task<IEnumerable<Todo>> ITodoRepository.GetAllTodos()
        {
            throw new System.NotImplementedException();
        }

        Task<Todo> ITodoRepository.GetTodo(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateTodo(Todo todo)
        {
            throw new System.NotImplementedException();
        }

        public Task<Todo> InsertTodo(Todo todo)
        {
            throw new System.NotImplementedException();
        }
    }
}