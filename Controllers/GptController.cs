using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGpt_csharp.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GptController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<ActionResult> UseChatGpt(string query)
        {
            string outputResult = "";
            var openai = new OpenAIAPI("secret web api key");
            
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = openai.Completions.CreateCompletionAsync(completionRequest);
            foreach(var completion in completions.Result.Completions)
            {
                outputResult += completion.Text;
            }
            return Ok(outputResult);
        }
    }
}
