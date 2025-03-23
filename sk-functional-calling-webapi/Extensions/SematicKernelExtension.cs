using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.SemanticKernel;
using sk_functional_calling_webapi.Models;
using sk_functional_calling_webapi.Plugin;

namespace sk_functional_calling_webapi.Extensions;


#pragma warning disable SKEXP0070

public static class SematicKernelExtension
{
    public static IServiceCollection AddSemanticKernel(this IServiceCollection services)
    {
        var builder = services.BuildServiceProvider();
        var httpClientFactory = builder.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient("ollamaClient");

        // Add Kernel and Chat Service
        services.AddKernel()
            .AddOllamaChatCompletion("llama3.2", httpClient);
        // Add Plugins
        services.AddSingleton<KernelPlugin>(sp => KernelPluginFactory.CreateFromType<LightsPlugin>(serviceProvider: sp));

        return services;
    }
}
