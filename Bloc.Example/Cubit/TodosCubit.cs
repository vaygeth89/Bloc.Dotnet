﻿using Bloc.Example.Models;
using Bloc.Example.Repositories;
using Bloc.Example.States;
using Bloc.Models;

namespace Bloc.Example.Cubit;

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