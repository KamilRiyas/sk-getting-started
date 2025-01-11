using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel.ChatCompletion;

namespace sk_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        public readonly IChatCompletionService _chatCompletionService;
        public ChatController(IChatCompletionService chatCompletionService)
        {
            _chatCompletionService = chatCompletionService;
        }

        [HttpGet]
        public async Task<string?> GetCharResponseAsync(string input)
        {
            if (input != null)
            {
                var chatResult = await _chatCompletionService.GetChatMessageContentsAsync(input);
                return chatResult[0].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
