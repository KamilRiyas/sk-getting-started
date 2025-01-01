using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = Kernel.CreateBuilder();
var uri = new Uri("http://localhost:11434");

#pragma warning disable SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
builder.Services.AddOllamaChatCompletion("llama3.2", uri);
#pragma warning restore SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

var kernel = builder.Build();
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

try
{
    ChatMessageContent chatMessage = await chatCompletionService
                                    .GetChatMessageContentAsync("Hi, can you tell me a dad joke");
    Console.WriteLine(chatMessage.ToString());
}
catch (Exception ex)
{
    System.Console.WriteLine(ex.Message);
}


