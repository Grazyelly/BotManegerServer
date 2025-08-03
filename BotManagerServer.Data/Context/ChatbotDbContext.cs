using BotManagerServer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BotManagerServer.Data.Context
{
    public class ChatbotDbContext : DbContext
    {
        public ChatbotDbContext(DbContextOptions<ChatbotDbContext> options) : base(options) { }

        public DbSet<Chatbot> Chatbots { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
    }
}
