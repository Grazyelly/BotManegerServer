namespace BotManagerServer.Core.Entities
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string TextoUsuario { get; set; }
        public string RespostaBot { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
        public int ChatbotId { get; set; }
        //public Chatbot Chatbot { get; set; }
    }
}
