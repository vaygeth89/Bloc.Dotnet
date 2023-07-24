namespace Bloc.Models;

public abstract class BlocBase<TState> where TState : BlocState
{
    protected TState State { get; set; }
    protected abstract void Emit(TState newState);

    public abstract event Action<TState>? OnStateChanged;
}