using OpenAI_API.Completions;
using OpenAI_API;
using PocketDr.Api.Repositories.ChatGPT.Interfaces;
using Microsoft.Extensions.Options;

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
            var messages = new List<dynamic>
            {
                new { role = "system", text = _appSettings.HealthCarePrompt },
                new { role = "user", text = input }
            };

            string outputResult = "";
            var openai = new OpenAIAPI(_appSettings.OpenAiKey);

            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = string.Join("", messages);
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
