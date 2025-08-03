using BotManagerServer.Core.Interfaces;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BotManagerServer.ExternalService.Services;

public class OpenAIService : IOpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "SUA_API_KEY";

    public OpenAIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> ObterRespostaAsync(string contexto, string pergunta)
    {
        var request = new
        {
            contents = new[]
            {
                new { role = "user", parts = new[] { new { text = contexto } } },
                new { role = "user", parts = new[] { new { text = pergunta } } }
            },
            model = "gemini-1.5-flash-latest"
        };

        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://generativelanguage.googleapis.com/v1beta/models/{request.model}:generateContent?key=AIzaSyCwBFe6AZfNBiziqC6KePUDWyYb894wewk", content);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro ao se comunicar com a API do Gemini: {response.StatusCode} - {errorContent}");
        }

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        var json = await response.Content.ReadAsStringAsync();
        var resultado = JsonDocument.Parse(json);

        return resultado.RootElement
                        .GetProperty("candidates")[0]
                        .GetProperty("content")
                        .GetProperty("parts")[0]
                        .GetProperty("text")
                        .GetString();
    }
}
