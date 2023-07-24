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

        #endregion

        #region Events

        listener1.BlocBuilder.Bloc.IncrementCount(valueToAdd);

        #endregion

        #region Assertions

        listener2.BlocBuilder.Bloc.OnStateChanged += listenToEvent;
        Assert.True(listener2.BlocBuilder.State.Count == valueToAdd);

        #endregion
    }

    public void listenToEvent(CountState state)
    {
        Assert.True(state.Count == valueToAdd);
    }
}