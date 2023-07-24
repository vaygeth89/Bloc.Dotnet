## BLoC

Overview
This package aims to implement Business Logic Component (BLoC) Design Pattern for Mutating and Sharing States

### Getting Started

To begin using the BLoC, you need to understand the key classes it provides for implementing the BLoC (Business Logic
Component) pattern in your .NET applications

#### Creating State Class
Create the class that will hold the data. In this example we will use Counter example
```csharp

public record CountState(int Count = 0) : BlocState;

```

#### Creating BLoC/Cubit Class

```csharp

public class CountCubit : Cubit<CountState>
{
    public CountCubit() : base(new CountState())
    {
    }

    public void Increment()
    {
        int currentCount = State.Count;
        Emit(new CountState(currentCount + 1));
    }

    public void Decrement()
    {
        int currentCount = State.Count;
        if (currentCount > 0)
        {
            Emit(new CountState(currentCount - 1));
        }
    }
}

```



#### Using BLocBuilder
You can inject your builder in your services or any class 

#### Program.cs
```csharp
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    // rest of the code....
    // ...

    builder.Services.AddScoped(sp => new BlocBuilder<CountCubit, CountState>(new CountCubit()));
    // rest of the code....
    // ...

    await builder.Build().RunAsync();
```

And using it as follows:

```csharp
    public class MyCountService {
        private BlocBuilder<CountCubit, CountState> Builder { get; set; }

        public MyCountService(BlocBuilder<CountCubit, CountState> builder){
            Builder = builder;
        }
    }
```

#### Handling Events
You can use the **Builder** to invoke the desired events, in this example **Increment**/**Decrement**

```csharp
    private void IncrementCount()
    {
        Builder.Bloc.Increment();
    }
```



### Contribute
https://github.com/vaygeth89/Bloc.Dotnet

### Acknowledgments
This package is inspired from the Dart package https://pub.dev/packages/bloc
