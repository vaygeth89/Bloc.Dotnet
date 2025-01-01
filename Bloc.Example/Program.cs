using Bloc.Example.Cubit;
using Bloc.Example.Models;
using Bloc.Example.Repositories;
using Bloc.Example.States;
using Refit;

ITodoRepository todoRepository = RestService.For<ITodoRepository>("https://jsonplaceholder.typicode.com/todos");

TodosCubit todosCubit = new TodosCubit(todoRepository);

todosCubit.OnStateChanged += OnTodosStateChanged;

await todosCubit.Load();
await todosCubit.Create(new Todo()
{
    Id = 0,
    Title = "Test",
    UserId = 1,
    Completed = false
});
await todosCubit.Delete(1);

//Try to get a todo with Id that doesn't exist to throw error
await todosCubit.GetTodoById(999);

void OnTodosStateChanged(TodosState state)
{
    if (state is TodosInitialState initialState)
    {
        Console.WriteLine("Initial State");
    }
    else if (state is TodosLoadingState loadingState)
    {
        Console.WriteLine("Loading State");
    }
    else if (state is TodosLoadedState loadedState)
    {
        Console.WriteLine($"Loaded State: Todos Count {loadedState.Todos.Count}");
        
    }
    else if (state is TodosCreatingState creatingState)
    {
        Console.WriteLine($"Creating State {creatingState.Todo.ToString()}");
    }
    else if (state is TodosDeletingState deletingState)
    {
        Console.WriteLine($"Deleting State: Removing Todo Id {deletingState.Id}");
    }
    else if (state is TodosErrorState errorState)
    {
        Console.WriteLine($"Error State: Error Message: {errorState.ErrorMessage}");
    }
    Console.WriteLine("===========");
}