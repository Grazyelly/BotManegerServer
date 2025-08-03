using BotManagerServer.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotManagerServer.Data.Repositories.Interfaces
{
    public interface IDesignTimeDbContextFactory
    {
        ChatbotDbContext CreateDbContext(string[] args);
    }
}
