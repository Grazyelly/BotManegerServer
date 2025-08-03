using BotManagerServer.Core.Interfaces;
using BotManagerServer.Core.Interfaces.Repositories;
using BotManagerServer.Data.Repositories;
using BotManagerServer.ExternalService.Services;
using BotManagerServer.Infra.Services;

namespace BotManagerServer.API.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        services.AddScoped<IChatbotService, ChatbotService>();
        services.AddScoped<IOpenAIService, OpenAIService>();
        services.AddScoped<IChatbotRepository, ChatbotRepository>();
        services.AddScoped<IMensagemRepository, MensagemRepository>();
        services.AddHttpClient();

        return services;
    }
}
