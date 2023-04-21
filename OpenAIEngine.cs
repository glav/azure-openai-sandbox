using System;
using System.Text;
using System.Threading;
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

            var dummyPrompt = new AIPrompt("ACME Jeweler","Azure integration platform for single view of the customer","Integrated data from dynamics 365, and other sub systems to provide a fast, 360 degree view of a customer record. Benefits to customer: Abstract sub system complexitites, fast view of an entire customer record including sales/orders, foundation platform for future development.");
            dummyPrompt.AddTechnologyUsedItem("Azure, API Management, Service Bus, Azure container apps, private Vnet, Cosmos DB");
            dummyPrompt.AddTechnologyUsedItem("API Management");
            dummyPrompt.AddTechnologyUsedItem("Service Bus");
            dummyPrompt.AddTechnologyUsedItem("Azure container apps");
            dummyPrompt.AddTechnologyUsedItem("private Vnet");
            dummyPrompt.AddTechnologyUsedItem("Cosmos DB");
            dummyPrompt.AddTechnologyUsedItem("NSG");

            //string prompt = "Can you write a poem about unicorns and cats?";
            string prompt = dummyPrompt.ToString();
            Console.WriteLine($"Input: {prompt}\n");
            Console.WriteLine("[{0}].... calling open AI service.",DateTime.Now.ToString("hh:mm:ss.ffff"));

            var options = new CompletionsOptions();
            options.MaxTokens = 800; // need to allow for bigger input - set statically while playing around
            options.Prompts.Add(prompt);
            Response<Completions> completionsResponse =
                 await client.GetCompletionsAsync(_config.ModelName,options);

            Console.WriteLine("[{0}].... completed calling open AI service.\n",DateTime.Now.ToString("hh:mm:ss.ffff"));
            string completion = completionsResponse.Value.Choices[0].Text;
            Console.WriteLine($"Chatbot: {completion}");
        }
    }
}