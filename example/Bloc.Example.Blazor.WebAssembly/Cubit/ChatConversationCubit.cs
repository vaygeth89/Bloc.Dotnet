using Bloc.Example.Blazor.WebAssembly.Models;
using Bloc.Example.Blazor.WebAssembly.Repositories;
using Bloc.Example.Blazor.WebAssembly.States;
using Bloc.Models;

namespace Bloc.Example.Blazor.WebAssembly.Cubit;

public class ChatConversationCubit(IChatConversationRepository repository)
    : Cubit<ChatConversationState>(ChatConversingState.Empty)
{
    public async Task SendMessage(string message)
    {
        List<ChatConversation> conversations = State.Conversations;
        conversations.Add(new ChatConversation(message));
        Emit(new ChatConversationSendingState(State.Conversations, message));
        ChatConversation lastMessage = await repository.SendMessage(message);
        conversations.Last().Id = lastMessage.PreviousConversationId ?? 0;
        conversations.Add(lastMessage);
        Emit(new ChatConversingState(conversations));
    }

    public override void Dispose()
    {
        Emit(ChatConversingState.Empty);
    }
}