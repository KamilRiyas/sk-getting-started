using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace sk_functional_calling_webapi.Controllers;

public record UserChatRequest(string query);

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly Kernel _kernel;
    private readonly ILogger<ChatController> _logger;

    public ChatController(Kernel Kernel, ILogger<ChatController> logger)
    {
        _kernel = Kernel;
        _logger = logger;
    }

    [HttpPost]
    public async Task<string> GetResponse(UserChatRequest chatRequest)
    {
        var chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();
        if (chatRequest.query != null)
        {
            PromptExecutionSettings settings = new() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() };
            var chatResult = await _kernel.InvokePromptAsync(chatRequest.query, new(settings));
            Console.WriteLine(chatResult.ToString());
            return chatResult.ToString();
        }
        else
        {
            return null;
        }
    }
}
