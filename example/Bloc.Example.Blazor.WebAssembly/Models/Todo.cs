namespace Bloc.Example.Blazor.WebAssembly.Models;

public class Todo(string title)
{
    public long Id { get; set; }
    public string Title { get; set; } = title;
    public long UserId { get; set; }
    public bool Completed { get; set; }

    public override string ToString()
    {
        return $"Id:{Id} - Title:{Title} - Completed:{Completed}";
    }
    
}