using Bloc.Models;
using Bloc.Test.Count.Models;

namespace Bloc.Test.Count;

public class CountBlocUnitTest
{
    private readonly BlocBuilder<CountCubit, CountState> _blocBuilder
        = new(new CountCubit());

    private int _valueToAdd = 5;

    [Fact]
    public void WatchChanges_Successfully()
    {
        #region Setup

        BlocListener1 listener1 = new BlocListener1(_blocBuilder);
        BlocListener2 listener2 = new BlocListener2(_blocBuilder);
        listener2.BlocBuilder.Bloc.OnStateChanged += (s) => ListenForValueToAdd(s, _valueToAdd);
        #endregion

        Assert.False(listener1.BlocBuilder.State is null);

        #region Events

        listener1.BlocBuilder.Bloc.IncrementCount(_valueToAdd);

        #endregion

        #region Assertions

        
        Assert.True(listener2.BlocBuilder.State.Count == _valueToAdd);

        _valueToAdd = 0;
        listener1.BlocBuilder.Bloc.Dispose();
        Assert.True(listener1.BlocBuilder.State.Count == 0);

        #endregion
    }

    private void ListenForValueToAdd(CountState state, int valueToCompare)
    {
        Assert.True(state.Count == valueToCompare);
    }
}