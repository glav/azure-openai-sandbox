using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace azure_openai_sandbox
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Console with App Settings!");

            var appConfig = LoadAppSettings();

            if (appConfig == null)
            {
                Console.WriteLine("Missing or invalid appsettings.json...exiting");
                return;
            }

            var config = new Config { 
                Endpoint = appConfig["endpoint"], 
                ApiKey = appConfig["apiKey"], 
                ModelName = appConfig["aiModelName"]};
            
			Console.WriteLine("Using OpenAI endpoint: [{0}], model name [{1}]",config.Endpoint,config.ModelName);

            var openAi = new OpenAIEngine(config);
            await openAi.RunGenerator();
        }
        static IConfigurationRoot LoadAppSettings()
        {
			var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var appConfig = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddJsonFile($"appsettings.local.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            return appConfig;
        }
    }

}
