namespace BotManagerServer.Core.Entities
{
    public class Chatbot
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contexto { get; set; }

        public List<Mensagem> Mensagens { get; set; } = new();
    }
}
