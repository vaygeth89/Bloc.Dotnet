namespace Bloc.Models;

public class Cubit<TState> : BlocBase<TState> where TState : BlocState
{
    public Cubit(TState state)
    {
        State = state;
        OnStateChanged?.Invoke(State);
    }

    protected override void Emit(TState newState)
    {
        State = newState;
        OnStateChanged?.Invoke(State);
    }

    public override event Action<TState>? OnStateChanged;

    public void Dispose()
    {
        //Handle your dispose method
    }
}