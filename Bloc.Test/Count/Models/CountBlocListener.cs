using Bloc.Models;

namespace Bloc.Test.Count.Models;

public class BlocListener1(BlocBuilder<CountCubit, CountState> blocBuilder)
{
    public BlocBuilder<CountCubit, CountState> BlocBuilder { get; } = blocBuilder;
}

public class BlocListener2(BlocBuilder<CountCubit, CountState> blocBuilder)
{
    public BlocBuilder<CountCubit, CountState> BlocBuilder { get; } = blocBuilder;
}