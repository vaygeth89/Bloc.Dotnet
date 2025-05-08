namespace Bloc.Models;

public class Cubit<TState>(TState state) : BlocBase<TState>(state) where TState : class
{
    protected override void Emit(TState newState)
    {
        State = newState;
        OnStateChanged?.Invoke(State);
    }

    public override event Action<TState>? OnStateChanged;

    public override void Dispose()
    {
        //Handle your dispose method
    }
}