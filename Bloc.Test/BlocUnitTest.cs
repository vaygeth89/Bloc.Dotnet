using Bloc.Models;
using Bloc.Test.Models;

namespace Bloc.Test;

public class BlocUnitTest
{
    private BlocBuilder<CountCubit, CountState> BlocBuilder
        = new(new CountCubit());

    private int valueToAdd = 5;

    [Fact]
    public void WatchChanges_Successfully()
    {
        #region Setup

        BlocListener1 listener1 = new BlocListener1(BlocBuilder);
        BlocListener2 listener2 = new BlocListener2(BlocBuilder);
        listener2.BlocBuilder.Bloc.OnStateChanged += (s) => ListenForValueToAdd(s, valueToAdd);
        #endregion

        Assert.False(listener1.BlocBuilder.State is null);

        #region Events

        listener1.BlocBuilder.Bloc.IncrementCount(valueToAdd);

        #endregion

        #region Assertions

        
        Assert.True(listener2.BlocBuilder.State.Count == valueToAdd);

        valueToAdd = 0;
        listener1.BlocBuilder.Bloc.Dispose();
        Assert.True(listener1.BlocBuilder.State.Count == 0);

        #endregion
    }

    public void ListenForValueToAdd(CountState state, int valueToCompare)
    {
        Assert.True(state.Count == valueToCompare);
    }
}