using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace TodoAPI_2.Todos
{
    public class TodoRepository : ITodoRepository
    {
        private IDbConnection DbConnection { get; }

        public TodoRepository(IDbConnection dbConnection)
        {          
            DbConnection = dbConnection;
        }
        
        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            const string sql = "SELECT * FROM[dbo].[Todo]";
            return await DbConnection.QueryAsync<Todo>(sql);
        }
        public async Task<Todo> GetTodo(int id)
        {
            string sql = @"SELECT* FROM[dbo].[Todo] WHERE Id = @Id";
            var result = await DbConnection.QueryFirstOrDefaultAsync<Todo>(sql, new { Id = id });
            return result;
        }

        public async Task<bool> UpdateTodo(Todo todo)
        {
            string sql = @"UPDATE [dbo].[Todo]
                            SET [IsChecked] = @IsChecked
                            ,[Content] = @Content
                            WHERE Id = @Id";
            await DbConnection.QueryFirstOrDefaultAsync<Todo>(sql, new { todo.Id, todo.IsChecked, todo.Content });
            return true;
        }

        public async Task<Todo> InsertTodo(Todo todo)
        {
            string sql = @"INSERT INTO [dbo].[Todo]
                        ([IsChecked]
                        ,[Content])
                        VALUES
                        (@IsChecked
                        ,@Content);SELECT CAST(SCOPE_IDENTITY() as int)";
            var newId = await DbConnection.QuerySingleAsync<int>(sql, new { todo.IsChecked, todo.Content });
            var result = await GetTodo(newId);
            return result;
        }

        public async Task DeleteTodo(int Id)
        {
            string sql = @"DELETE FROM [dbo].[Todo]
                         WHERE Id = @Id";
            await DbConnection.ExecuteAsync(sql, new { Id });
            
        }
    }
}