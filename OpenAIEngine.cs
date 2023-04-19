using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;

namespace azure_openai_sandbox
{
    public class OpenAIEngine
    {
        private readonly Config _config;
        public OpenAIEngine(Config config)
        {
            _config = config;
        }

        public async Task RunGenerator()
        {
            var client = new OpenAIClient(new Uri(_config.Endpoint), new AzureKeyCredential(_config.ApiKey));

            string prompt = "Can you write a poem about unicorns and cats?";
            Console.WriteLine($"Input: {prompt}\n");
            Console.WriteLine("[{0}].... calling open AI service.",DateTime.Now.ToString("hh:mm:ss.ffff"));

            Response<Completions> completionsResponse =
                await client.GetCompletionsAsync(_config.ModelName, prompt);
            Console.WriteLine("[{0}].... completed calling open AI service.\n",DateTime.Now.ToString("hh:mm:ss.ffff"));
            string completion = completionsResponse.Value.Choices[0].Text;
            Console.WriteLine($"Chatbot: {completion}");
        }
    }
}