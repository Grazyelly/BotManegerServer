using BotManagerServer.Core.Entities;

namespace BotManagerServer.Core.Interfaces.Repositories;

public interface IMensagemRepository
{
    Task<List<Mensagem>> ObterPorChatbotIdAsync(int chatbotId);
    Task AdicionarAsync(Mensagem mensagem);
    Task SalvarAsync();
}
