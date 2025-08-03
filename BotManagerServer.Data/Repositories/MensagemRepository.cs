using BotManagerServer.Core.Entities;
using BotManagerServer.Core.Interfaces.Repositories;
using BotManagerServer.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BotManagerServer.Data.Repositories;

public class MensagemRepository : IMensagemRepository
{
    private readonly ChatbotDbContext _context;

    public MensagemRepository(ChatbotDbContext context)
    {
        _context = context;
    }

    public async Task<List<Mensagem>> ObterPorChatbotIdAsync(int chatbotId)
    {
        return await _context.Mensagens
            .Where(m => m.ChatbotId == chatbotId)
            .OrderBy(m => m.DataHora)
            .ToListAsync();
    }

    public async Task AdicionarAsync(Mensagem mensagem)
    {
        await _context.Mensagens.AddAsync(mensagem);
    }

    public async Task SalvarAsync()
    {
        await _context.SaveChangesAsync();
    }
}
