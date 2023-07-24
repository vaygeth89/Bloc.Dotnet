using Bloc.Models;

namespace Bloc.Test;

public class BlocUnitTest
{
    private BlocBuilder<CountCubit, CountState> BlocBuilder
        = new BlocBuilder<CountCubit, CountState>(new CountCubit());

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

public class BlocListener1
{
    public BlocBuilder<CountCubit, CountState> BlocBuilder { get; }

    public BlocListener1(BlocBuilder<CountCubit, CountState> blocBuilder)
    {
        BlocBuilder = blocBuilder;
    }
}

public class BlocListener2
{
    public BlocBuilder<CountCubit, CountState> BlocBuilder { get; }

    public BlocListener2(BlocBuilder<CountCubit, CountState> blocBuilder)
    {
        BlocBuilder = blocBuilder;
    }
}

public record CountState(int Count) : BlocState;

public class CountCubit : Cubit<CountState>
{
    public CountCubit() : base(new CountState(0))
    {
    }

    public void IncrementCount(int incrementBy = 1)
    {
        var currentCount = State.Count;
        Emit(new CountState(currentCount + incrementBy));
    }

    public void DecrementCount(int decrementBy = 1)
    {
        var currentCount = State.Count;
        Emit(new CountState(currentCount - decrementBy));
    }
}