using OpenAI.Chat;

namespace BotManagerServer.ExternalService.Models
{
    public sealed class ChatRequest
    {
        public string Model { get; set; }
        public List<ChatMessage> Messages { get; set; } = new();
        public double? Temperature { get; set; }
        public int? MaxTokens { get; set; }
        public double? TopP { get; set; }
        public double? FrequencyPenalty { get; set; }
        public double? PresencePenalty { get; set; }
        public string[] Stop { get; set; }
        public bool? Stream { get; set; }
        public string User { get; set; }
    }
}
