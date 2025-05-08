using Bloc.Example.Blazor.WebAssembly.Models;

namespace Bloc.Example.Blazor.WebAssembly.States;

public abstract record ChatConversationState(List<ChatConversation> Conversations);

public record ChatConversingState(List<ChatConversation> Conversations) : ChatConversationState(Conversations)
{
    public static ChatConversingState Empty => new(new List<ChatConversation>());
}

public record ChatConversationSendingState(List<ChatConversation> Conversations, string CurrentMessage)
    : ChatConversationState(Conversations);

public record ChatConversationErrorState(List<ChatConversation> Conversations) : ChatConversationState(Conversations);