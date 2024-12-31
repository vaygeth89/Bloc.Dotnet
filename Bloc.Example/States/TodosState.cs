using Bloc.Example.Models;

namespace Bloc.Example.States;

public abstract record TodosState(List<Todo> Todos);

public record TodosInitialState() : TodosState(new List<Todo>());

public record TodosLoadedState(List<Todo> Todos) : TodosState(Todos);

public record TodosLoadingState(List<Todo> Todos) : TodosState(Todos);

public record TodosCreatingState(Todo Todo, List<Todo> Todos) : TodosState(Todos);

public record TodosDeletingState(long Id, List<Todo> Todos) : TodosState(Todos);

public record TodosErrorState(string ErrorMessage, List<Todo> Todos) : TodosState(Todos);