using Bloc.Models;

namespace Bloc.Test.Models;

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