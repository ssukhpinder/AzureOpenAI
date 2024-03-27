// Implicit using statements are included
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;


// Build a config object and retrieve user settings.
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string? oaiEndpoint = config["AzureOAIEndpoint"];
string? oaiKey = config["AzureOAIKey"];
string? oaiDeploymentName = config["AzureOAIDeploymentName"];

if (string.IsNullOrEmpty(oaiEndpoint) || string.IsNullOrEmpty(oaiKey) || string.IsNullOrEmpty(oaiDeploymentName))
{
    Console.WriteLine("Please check your appsettings.json file for missing or incorrect values.");
    return;
}


string systemMessage = "You are an AI assistant helping to write emails\r\n";

// Initialize the Azure OpenAI client
OpenAIClient client = new OpenAIClient(new Uri(oaiEndpoint), new AzureKeyCredential(oaiKey));


do
{
    Console.WriteLine("Enter your prompt text (or type 'quit' to exit): ");
    string? inputText = Console.ReadLine();
    if (inputText == "quit") break;

    // Generate summary from Azure OpenAI
    if (inputText == null)
    {
        Console.WriteLine("Please enter a prompt.");
        continue;
    }

    Console.WriteLine("\nSending request for summary to Azure OpenAI endpoint...\n\n");

    // Add code to send request...
    ChatCompletionsOptions chatCompletionsOptions = new ChatCompletionsOptions()
    {
        Messages =
        {
            new ChatRequestSystemMessage(systemMessage),
            new ChatRequestUserMessage(inputText),
        },
        MaxTokens = 400,
        Temperature = 0.7f,
        DeploymentName = oaiDeploymentName
    };

    ChatCompletions chatCompletions = client.GetChatCompletions(chatCompletionsOptions);

    string completion = chatCompletions.Choices[0].Message.Content;
    Console.WriteLine("Response: " + completion + "\n");

} while (true);
