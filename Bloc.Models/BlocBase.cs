namespace Bloc.Models;

public abstract class BlocBase<TState> where TState : BlocState
{
    public TState State { get; internal set; }
    protected abstract void Emit(TState newState);

    public abstract event Action<TState>? OnStateChanged;

    public abstract void Dispose();
}