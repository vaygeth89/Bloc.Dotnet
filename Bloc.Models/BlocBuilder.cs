namespace Bloc.Models;

public class BlocBuilder<TBloc, TState> where TBloc : BlocBase<TState> where TState : BlocState
{
    public TBloc Bloc { get; }
    public event Action<TState> Build;
    public TState State { get; internal set; }

    public BlocBuilder(TBloc bloc)
    {
        Bloc = bloc;
        Bloc.OnStateChanged += UpdateState;
    }

    private void UpdateState(TState state)
    {
        State = state;
        Build.Invoke(State);
    }
}