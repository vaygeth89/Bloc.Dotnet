namespace Bloc.Models;

public class Cubit<TState> : BlocBase<TState> where TState : BlocState
{
    public Cubit(TState state)
    {
        State = state;
    }

    protected override void Emit(TState newState)
    {
        State = newState;
        OnStateChanged.Invoke(State);
    }

    public override event Action<TState>? OnStateChanged;
}