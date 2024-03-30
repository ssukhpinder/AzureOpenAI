// See https://aka.ms/new-console-template for more information


// Build a config object and retrieve user settings.
using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
string? endpoint = config["AzureEndpoint"];
string? apiKey = config["AzureKey"];
string? documentUrl = config["DocumentUrl"];

Uri fileUri = new Uri(uriString: documentUrl);

Console.WriteLine("\nConnecting to Forms Recognizer at: {0}", endpoint);
Console.WriteLine("Analyzing invoice at: {0}\n", fileUri.ToString());

// Create the client

var cred = new AzureKeyCredential(apiKey);
var client = new DocumentAnalysisClient(new Uri(endpoint), cred);

// Analyze the invoice
AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, "prebuilt-invoice", fileUri);
await operation.WaitForCompletionAsync();

// Display invoice information to the user
AnalyzeResult result = operation.Value;

foreach (AnalyzedDocument invoice in result.Documents)
{
    if (invoice.Fields.TryGetValue("VendorName", out DocumentField? vendorNameField))
    {
        if (vendorNameField.FieldType == DocumentFieldType.String)
        {
            string vendorName = vendorNameField.Value.AsString();
            Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}.");
        }
    }



    if (invoice.Fields.TryGetValue("CustomerName", out DocumentField? customerNameField))
    {
        if (customerNameField.FieldType == DocumentFieldType.String)
        {
            string customerName = customerNameField.Value.AsString();
            Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}.");
        }
    }

    if (invoice.Fields.TryGetValue("InvoiceTotal", out DocumentField? invoiceTotalField))
    {
        if (invoiceTotalField.FieldType == DocumentFieldType.Currency)
        {
            CurrencyValue invoiceTotal = invoiceTotalField.Value.AsCurrency();
            Console.WriteLine($"Invoice Total: '{invoiceTotal.Symbol}{invoiceTotal.Amount}', with confidence {invoiceTotalField.Confidence}.");
        }
    }
}
Console.WriteLine("\nAnalysis complete.\n");