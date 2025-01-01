using Bloc.Example.Models;
using Refit;

namespace Bloc.Example.Repositories;

public interface ITodoRepository
{
    [Get("/")]
    public Task<List<Todo>> GetTodos();

    [Get("/")]
    public Task<List<Todo>> GetTodoById([Query("id")] long id);

    [Post("/")]
    public Task<Todo> CreateTodo([Body] Todo todo);

    [Delete("/{id}")]
    public Task<Todo> DeleteTodo([AliasAs("id")] long id);
}