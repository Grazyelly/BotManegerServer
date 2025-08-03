using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using BotManagerServer.Data.Context;
using SQLitePCL;

namespace BotManagerServer.Data
{
    public class ChatbotDbContextFactory : IDesignTimeDbContextFactory<ChatbotDbContext>
    {
        public ChatbotDbContext CreateDbContext(string[] args)
        {
            Batteries.Init();

            var optionsBuilder = new DbContextOptionsBuilder<ChatbotDbContext>();
            optionsBuilder.UseSqlite("Data Source=chatbots.db");

            return new ChatbotDbContext(optionsBuilder.Options);
        }
    }
}
