using Bloc.Example.Blazor.WebAssembly.Models;

namespace Bloc.Example.Blazor.WebAssembly.Repositories;

public interface IChatConversationRepository
{
    Task<List<ChatConversation>> History();
    Task<ChatConversation> SendMessage(string message);
}

public class ChatConversationRepository : IChatConversationRepository
{
    private List<ChatConversation> _history = new();

    public async Task<List<ChatConversation>> History()
    {
        //Simulate a network delay
        await Task.Delay(200);
        return _history;
    }

    public async Task<ChatConversation> SendMessage(string message)
    {
        //Simulate a network delay
        _history.Add(new ChatConversation(message, id: _history.Count + 1,
            previousConversationId: _history.Count > 0 ? _history.Last().Id : null));
        await Task.Delay(1000);
        string randomMessage = Faker.Lorem.Sentence(3);
        _history.Add(new ChatConversation(randomMessage, true, id: _history.Count + 1,
            previousConversationId: _history.Last().Id));
        return _history.Last();
    }
}