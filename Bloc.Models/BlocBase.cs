namespace Bloc.Models;

public abstract class BlocBase<TState>(TState initialState)
    where TState : class
{
    public TState State { get; internal set; } = initialState;
    protected abstract void Emit(TState newState);

    public abstract event Action<TState>? OnStateChanged;

    public abstract void Dispose();
}