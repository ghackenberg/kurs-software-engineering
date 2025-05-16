using System.Text.Json;

namespace Entwurfsmuster
{
    public interface ProxySchnittstelle
    {
        Task<int> Dienst(int a, int b);
    }

    public class InputNachricht
    {
        public int A;
        public int B;
    }
    public class OutputNachricht
    {
        public int R;
    }

    public class Proxy : ProxySchnittstelle
    {
        private HttpClient client = new HttpClient();

        private string url = "https://domain/pfad/";

        public async Task<int> Dienst(int a, int b)
        {
            // InputNachricht erstellen und in JSON-Darstellung konvertieren
            var input = new InputNachricht { A = a, B = b };
            var inputJson = JsonSerializer.Serialize(input);
            var inputContent = new StringContent(inputJson);

            // InputNachricht über HTTP an Dienst-Implementierung senden und Antwort empfangen
            var antwort = await client.PostAsync(url, inputContent);

            // JSON-Darstellung in OutputNachricht konvertieren und Rückgabewert auslesen
            var outputJson = await antwort.Content.ReadAsStringAsync();
            var output = JsonSerializer.Deserialize<OutputNachricht>(outputJson);
            return output != null ? output.R : 0;
        }
    }
}

