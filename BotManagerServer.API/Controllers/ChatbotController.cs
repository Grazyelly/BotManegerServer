using BotManagerServer.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BotManagerServer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatbotController : ControllerBase
{
    private readonly IChatbotService _chatbotService;

    public ChatbotController(IChatbotService chatbotService)
    {
        _chatbotService = chatbotService;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(string nome, string contexto)
    {
        var botCriado = await _chatbotService.CriarBotAsync(nome, contexto);
        return Ok(botCriado);
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> Obter(int id)
    //{
    //    var bot = await _chatbotService.ObterBotsAsync(id);
    //    return bot == null ? NotFound() : Ok(bot);
    //}

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var bots = await _chatbotService.ObterBotsAsync();
        return Ok(bots);
    }

    [HttpDelete("{botId}")]
    public async Task<IActionResult> Delete(int botId)
    {
        var historico = await _chatbotService.DeletarBotAsync(botId);
        return Ok(historico);
    }

}
