## BLoC

Overview
This package aims to implement Business Logic Component (BLoC) Design Pattern for Handling State Changes. This package is inspired from the Dart package https://pub.dev/packages/bloc

### Getting Started
To begin using the BLoC, you need to understand the key classes it provides for implementing the BLoC (Business Logic Component) pattern in your .NET applications

```c# 
public abstract class BlocBase<TState> where TState : BlocState
{
protected TState State { get; set; }
protected abstract void Emit(TState newState);
public abstract event Action<TState>? OnStateChanged;
}
```

The BlocBase<TState> class is the core of the BLoC pattern and serves as an abstract base class for creating specific BLoC implementations. It defines the following properties and methods:

State: A protected property representing the current state of the BLoC. It can be accessed within the derived classes.
Emit(TState newState): An abstract method that allows emitting a new state. When called, it updates the current state with the provided newState and triggers the OnStateChanged event.
OnStateChanged: An abstract event that is triggered whenever the state changes. Subscribers can react to state changes and update the UI or perform other actions accordingly.
BlocBuilder<TBloc, TState> Class
csharp
Copy code
public class BlocBuilder<TBloc, TState> where TBloc : BlocBase<TState> where TState : BlocState
{
public TBloc Bloc { get; }
public TState State { get; internal set; }

    public BlocBuilder(TBloc bloc)
    {
        Bloc = bloc;
        Bloc.OnStateChanged += UpdateState;
    }

    private void UpdateState(TState state)
    {
        State = state;
    }
}
The BlocBuilder<TBloc, TState> class facilitates building UI components that react to changes in the BLoC's state. It offers the following features:

Bloc: A property representing the associated BLoC instance that you want to observe.
State: An internal property that holds the current state of the associated BLoC. It is automatically updated whenever the BLoC's state changes, triggering the UI to re-render accordingly.
BlocState Class
csharp
Copy code
public abstract record BlocState();
The BlocState class is an abstract record type used to define the state objects within your application. It serves as a marker for the state objects and should be extended for specific state implementations.

Cubit<TState> Class
csharp
Copy code
public class Cubit<TState> : BlocBase<TState> where TState : BlocState
{
public Cubit(TState state)
{
State = state;
}

    protected override void Emit(TState newState)
    {
        State = newState;
        OnStateChanged?.Invoke(State);
    }

    public override event Action<TState>? OnStateChanged;
}
The Cubit<TState> class is an implementation of BlocBase<TState> that simplifies state management for simple use cases. It provides the following functionality:

Cubit(TState state): A constructor that initializes the Cubit with an initial state.
Emit(TState newState): An overridden method that updates the current state with the provided newState and triggers the OnStateChanged event.
Example Usage
[Provide an example or step-by-step guide on how to use the classes in your package to implement the BLoC pattern in a specific scenario.]

Contribute
[Encourage users to contribute to the project and provide information on how to do so, including a link to your GitHub repository.]

License
[Include your chosen license here]

Acknowledgments
[If applicable, acknowledge any inspirations or third-party libraries used in your package]

