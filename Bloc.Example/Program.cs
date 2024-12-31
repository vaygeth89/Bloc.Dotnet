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
        Console.WriteLine("Loaded State");
        loadedState.Todos.ForEach(todo=>Console.WriteLine(todo.ToString()));
    }
    else if (state is TodosCreatingState creatingState)
    {
        Console.WriteLine("Creating State");
    }
    else if (state is TodosDeletingState deletingState)
    {
        Console.WriteLine("Deleting State");
    }
    else if (state is TodosErrorState errorState)
    {
        Console.WriteLine("Error State");
    }
}