using Bloc.Models;

namespace Bloc.Test.Models;

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

    public override void Dispose()
    {
        Emit(new CountState(0));
    }
}