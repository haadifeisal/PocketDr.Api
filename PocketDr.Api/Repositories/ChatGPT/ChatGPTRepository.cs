using OpenAI_API.Completions;
using OpenAI_API;
using PocketDr.Api.Repositories.ChatGPT.Interfaces;
using Microsoft.Extensions.Options;
using System.Runtime;

namespace PocketDr.Api.Repositories.ChatGPT
{
    public class ChatGPTRepository: IChatGPTRepository
    {
        private AppSettings _appSettings;
        public ChatGPTRepository(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }
        public async Task<string> ChatGPT(string input)
        {
            string outputResult = "";
            var openai = new OpenAIAPI(_appSettings.OpenAiKey);
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = input;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 1024;

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Completions)
            {
                outputResult += completion.Text;
            }

            return outputResult;
        }

    }
}
