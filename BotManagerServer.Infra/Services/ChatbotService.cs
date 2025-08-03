using BotManagerServer.Core.Entities;
using BotManagerServer.Core.Interfaces;
using BotManagerServer.Core.Interfaces.Repositories;

namespace BotManagerServer.Infra.Services;

public class ChatbotService : IChatbotService
{
    private readonly IChatbotRepository _chatbotRepository;
    private readonly IMensagemRepository _mensagemRepository;
    private readonly IOpenAIService _openAIService;

    public ChatbotService(
        IChatbotRepository chatbotRepository,
        IMensagemRepository mensagemRepository,
        IOpenAIService openAIService)
    {
        _chatbotRepository = chatbotRepository;
        _mensagemRepository = mensagemRepository;
        _openAIService = openAIService;
    }

    public async Task<Mensagem> EnviarMensagemAsync(int chatbotId, string textoUsuario)
    {
        var bot = await _chatbotRepository.ObterPorIdAsync(chatbotId)
            ?? throw new Exception("Bot não encontrado");

        var resposta = await _openAIService.ObterRespostaAsync(bot.Contexto, textoUsuario);

        var mensagem = new Mensagem
        {
            ChatbotId = chatbotId,
            TextoUsuario = textoUsuario,
            RespostaBot = resposta,
        };

        await _mensagemRepository.AdicionarAsync(mensagem);
        await _mensagemRepository.SalvarAsync();

        return mensagem;
    }

    public async Task<List<Mensagem>> ObterHistoricoAsync(int chatbotId)
    {
        return await _mensagemRepository.ObterPorChatbotIdAsync(chatbotId);
    }

    public async Task<List<Chatbot>> ObterBotsAsync()
    {
        return await _chatbotRepository.ObterTodosAsync();
    }

    public async Task<Chatbot> CriarBotAsync(string nome, string contexto)
    {

        var chatbot = new Chatbot
        {
            Nome = nome,
            Contexto = contexto,
        };

        await _chatbotRepository.AdicionarAsync(chatbot);
        await _chatbotRepository.SalvarAsync();

        return chatbot;
    }

    public async Task<bool> DeletarBotAsync(int chatbotId)
    {

        return await _chatbotRepository.DeletePorIdAsync(chatbotId);

    }
}
