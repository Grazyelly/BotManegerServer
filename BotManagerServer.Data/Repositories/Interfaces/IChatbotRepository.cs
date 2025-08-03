using BotManagerServer.Core.Entities;

namespace BotManagerServer.Core.Interfaces.Repositories;

public interface IChatbotRepository
{
    Task<Chatbot?> ObterPorIdAsync(int id);
    Task<List<Chatbot>> ObterTodosAsync();
    Task AdicionarAsync(Chatbot bot);
    Task<bool> DeletePorIdAsync(int id);
    Task SalvarAsync();

}
