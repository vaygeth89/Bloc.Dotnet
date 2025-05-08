namespace Bloc.Example.Blazor.WebAssembly.Models;

public class ChatConversation(string message, bool isSystem = false, long id = 0, long? previousConversationId = null)
{
    public long Id { get; set; } = id;
    public long? PreviousConversationId { get; set; } = previousConversationId;
    public string Message { get; set; } = message;
    public bool IsSystem { get; set; } = isSystem;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}