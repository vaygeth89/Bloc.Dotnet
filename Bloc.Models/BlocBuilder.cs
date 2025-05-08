namespace Bloc.Models;

public class BlocBuilder<TBloc, TState> where TBloc : BlocBase<TState> where TState : class
{
    public TBloc Bloc { get; }
    public TState State { get; private set; }

    public BlocBuilder(TBloc bloc)
    {
        Bloc = bloc;
        State = Bloc.State;
        Bloc.OnStateChanged += UpdateState;
    }

    private void UpdateState(TState state)
    {
        State = state;
    }
}