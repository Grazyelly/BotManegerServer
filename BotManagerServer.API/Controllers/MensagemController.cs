using BotManagerServer.Core.Interfaces;
using BotManagerServer.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace BotManagerServer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MensagemController : ControllerBase
{
    private readonly IChatbotService _chatbotService;

    public MensagemController(IChatbotService chatbotService)
    {
        _chatbotService = chatbotService;
    }

    [HttpPost("{botId}")]
    public async Task<IActionResult> EnviarMensagem(int botId, [FromBody] string texto)
    {
        var resposta = await _chatbotService.EnviarMensagemAsync(botId, texto);
        return Ok(resposta);
    }

    [HttpGet("{botId}")]
    public async Task<IActionResult> Historico(int botId)
    {
        var historico = await _chatbotService.ObterHistoricoAsync(botId);
        return Ok(historico);
    }
}
