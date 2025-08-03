namespace BotManagerServer.Core.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> ObterRespostaAsync(string contexto, string pergunta);
    }
}
