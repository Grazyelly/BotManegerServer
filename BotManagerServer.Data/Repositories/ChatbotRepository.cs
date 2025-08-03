using BotManagerServer.Core.Entities;
using BotManagerServer.Core.Interfaces.Repositories;
using BotManagerServer.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BotManagerServer.Data.Repositories;

public class ChatbotRepository : IChatbotRepository
{
    private readonly ChatbotDbContext _context;

    public ChatbotRepository(ChatbotDbContext context)
    {
        _context = context;
    }

    public async Task<Chatbot?> ObterPorIdAsync(int id)
    {
        return await _context.Chatbots
            .Include(c => c.Mensagens)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> DeletePorIdAsync(int id)
    {
        var rowsAffected = await _context.Chatbots
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();

        return rowsAffected > 0;
    }

    public async Task<List<Chatbot>> ObterTodosAsync()
    {
        return await _context.Chatbots.ToListAsync();
    }

    public async Task AdicionarAsync(Chatbot bot)
    {

        await _context.Chatbots.AddAsync(bot);
    }

    public async Task SalvarAsync()
    {
        await _context.SaveChangesAsync();
    }
}
