using BotManagerServer.Core.Entities;
using System.Threading.Tasks;

namespace BotManagerServer.Core.Interfaces
{
    public interface IChatbotService
    {
        Task<Mensagem> EnviarMensagemAsync(int chatbotId, string textoUsuario);
        Task<List<Mensagem>> ObterHistoricoAsync(int chatbotId);
        Task<List<Chatbot>> ObterBotsAsync();
        Task<Chatbot> CriarBotAsync(string nome, string contexto);
        Task<bool> DeletarBotAsync(int chatbotId);
    }
}
