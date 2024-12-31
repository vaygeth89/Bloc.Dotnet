namespace Bloc.Example.Models;

public class Todo
{
    public long Id { get; set; }
    public string Title { get; set; } = "";
    public long UserId { get; set; }
    public bool Completed { get; set; }
}