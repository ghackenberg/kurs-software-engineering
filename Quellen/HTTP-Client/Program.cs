using System.Text.Json;

namespace HTTP_Client
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        static async Task Run()
        {
            var client = new HttpClient();

            // URL definieren
            var url = "https://dog.ceo/api/breeds/list/all";

            // HTTP Anfrage senden und Antwort empfangen
            var response = await client.GetAsync(url);

            // Status-Code der Antwort prüfen
            response.EnsureSuccessStatusCode();

            // Body der Antwort auslesen
            var body = await response.Content.ReadAsStringAsync();

            // Body verarbeiten
            ProcessSchemaImplicit(body);
            ProcessSchemaExplicit(body);
        }

        static void ProcessSchemaImplicit(string body)
        {
            // Body-Zeichenkette in C#-Objekt konvertieren
            var document = JsonDocument.Parse(body);
            var root = document.RootElement;
            var message = root.GetProperty("message");

            // Body-Inhalte auf der Konsole ausgeben
            foreach (var item in message.EnumerateObject())
            {
                Console.WriteLine(item.Name);
                foreach (var subitem in item.Value.EnumerateArray())
                {
                    Console.WriteLine($"  {subitem.GetString()}");
                }
            }
        }

        class ResponseBodyDocument
        {
            public Dictionary<string, string[]>? message { get; set; }
            public string? status { get; set; }
        }

        static void ProcessSchemaExplicit(string body)
        {
            // Body-Zeichenkette in C#-Objekt konvertieren
            var document = JsonSerializer.Deserialize<ResponseBodyDocument>(body);

            // Body-Inhalte auf der Konsole ausgeben
            if (document?.message != null)
            {
                foreach (var item in document.message)
                {
                    Console.WriteLine(item.Key);
                    foreach (var subitem in item.Value)
                    {
                        Console.WriteLine($"  {subitem}");
                    }
                }
            }
        }
    }
}
