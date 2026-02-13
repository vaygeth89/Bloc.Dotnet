## BLoC

Overview
This package aims to implement Business Logic Component (BLoC) Design Pattern for Mutating and Sharing States

### Getting Started

To begin using the BLoC, you need to understand the key classes it provides for implementing the BLoC (Business Logic
Component) pattern in your .NET applications

### Examples

Blazor
* [Simple count application](example/Bloc.Example.Blazor.WebAssembly/Pages/Counter.razor)
* [API & Repositories](example/Bloc.Example.Blazor.WebAssembly/Pages/MyTodos.razor)
* [Chat Example](example/Bloc.Example.Blazor.WebAssembly/Pages/ChatPage/ChatPage.razor)

#### Usage
Create the class that will hold the data. In this example we will use a Todo CRUD/Repository Example
```csharp

public abstract record TodosState(List<Todo> Todos);

public record TodosInitialState() : TodosState(new List<Todo>());

public record TodosLoadedState(List<Todo> Todos) : TodosState(Todos);

public record TodosLoadingState(List<Todo> Todos) : TodosState(Todos);

public record TodosCreatingState(Todo Todo, List<Todo> Todos) : TodosState(Todos);

public record TodosDeletingState(long Id, List<Todo> Todos) : TodosState(Todos);

public record TodosErrorState(string ErrorMessage, List<Todo> Todos) : TodosState(Todos);

```

#### Creating BLoC/Cubit Class
Creating the Cubit class that will have events, business logic and interaction with APIs
```csharp

public class TodosCubit(ITodoRepository _repository) : Cubit<TodosState>(new TodosInitialState())
{
    public async Task Load()
    {
        Emit(new TodosLoadingState(State.Todos));
        List<Todo> todos = await _repository.GetTodos();
        Emit(new TodosLoadedState(todos));
    }

    public async Task Create(Todo todo)
    {
        Emit(new TodosCreatingState(todo, State.Todos));
        //This just a simulation for creating Todo, it will just return the dat with new Id
        Todo added = await _repository.CreateTodo(todo);
        List<Todo> todos = State.Todos;
        todos.Insert(0, added);
        Emit(new TodosLoadedState(todos));
    }

    public async Task Delete(long id)
    {
        Emit(new TodosDeletingState(id, State.Todos));
        await _repository.DeleteTodo(id);
        List<Todo> todos = State.Todos;
        var todoToRemove = todos.SingleOrDefault(t => t.Id == id);
        if (todoToRemove is not null)
        {
            todos.Remove(todoToRemove);
        }

        Emit(new TodosLoadedState(todos));
    }

    public async Task GetTodoById(long id)
    {
        Emit(new TodosLoadingState(State.Todos));
        var result = await _repository.GetTodoById(id);
        if (!result.Any())
        {
            Emit(new TodosErrorState("Todo Id not found", State.Todos));
            return;
        }

        Emit(new TodosLoadedState(State.Todos));
    }
}

```



#### Using BLocBuilder
You can inject your builder in your services or any class 

#### Program.cs
```csharp
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    // rest of the code....
    // ...

    builder.Services.AddScoped(sp => new BlocBuilder<CountCubit, CountState>(new CountCubit()));
    // rest of the code....
    // ...

    await builder.Build().RunAsync();
```

And using it as follows:

```csharp
    public class MyCountService {
        private BlocBuilder<CountCubit, CountState> Builder { get; set; }

        public MyCountService(BlocBuilder<CountCubit, CountState> builder){
            Builder = builder;
        }
    }
```

#### Handling Events
You can use the **Builder** to invoke the desired events, in this example **Increment**/**Decrement**

```csharp
    private void IncrementCount()
    {
        Builder.Bloc.Increment();
    }
```



### Contribute
https://github.com/vaygeth89/Bloc.Dotnet

### Acknowledgments
This package is inspired from the Dart package https://pub.dev/packages/bloc
