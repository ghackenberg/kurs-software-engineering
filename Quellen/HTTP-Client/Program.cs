using System.Text.Json;

namespace HTTP_Client
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Part 1: Breeds and sub-breeds

            ListBreeds().Wait();
            ListSubBreeds("hound").Wait();

            // Part 2: Images

            GetImage().Wait();
            ListImagesLimit(3).Wait();

            // Part 3: Breed images

            GetBreedImage("hound").Wait();
            ListBreedImages("hound").Wait();
            ListBreedImagesLimit("hound", 3).Wait();

            // Part 4: Sub-breed images

            GetSubBreedImage("hound", "afghan").Wait();
            ListSubBreedImages("hound", "afghan").Wait();
            ListSubBreedImagesLimit("hound", "afghan", 3).Wait();
        }

        // Part 1: Breeds and sub-breeds

        #region ListBreeds

        static async Task ListBreeds()
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
            ProcessListBreedsResponseImplicit(body);
            ProcessListBreedsResponseExplicit(body);
        }

        static void ProcessListBreedsResponseImplicit(string body)
        {
            // Body-Zeichenkette in C#-Objekt konvertieren
            var document = JsonDocument.Parse(body);

            // Wurzelelement des JSON-Dokuments auslesen
            var root = document.RootElement;

            // Kindelement des Wurzelelements auslesen
            var message = root.GetProperty("message");

            // Hunderassen verarbeiten
            foreach (var item in message.EnumerateObject())
            {
                // Name der Hunderasse ausgeben
                Console.WriteLine(item.Name);

                // Hundeunterrassen verarbeiten
                foreach (var subitem in item.Value.EnumerateArray())
                {
                    // Name der Hundeunterrasse ausgeben
                    Console.WriteLine($"  {subitem.GetString()}");
                }
            }
        }

        class ListBreedsResponse
        {
            public Dictionary<string, string[]>? message { get; set; }
            public string? status { get; set; }
        }

        static void ProcessListBreedsResponseExplicit(string body)
        {
            // Body-Zeichenkette in C#-Objekt konvertieren
            var document = JsonSerializer.Deserialize<ListBreedsResponse>(body);

            // Ergebnis prüfen
            if (document?.message != null)
            {
                // Hunderassen verarbeiten
                foreach (var item in document.message)
                {
                    // Name der Hunderasse ausgeben
                    Console.WriteLine(item.Key);

                    // Hundeunterrassen verarbeiten
                    foreach (var subitem in item.Value)
                    {
                        // Name der Hundeunterrasse ausgeben
                        Console.WriteLine($"  {subitem}");
                    }
                }
            }
        }

        #endregion

        #region ListSubBreeds

        static async Task ListSubBreeds(string breed)
        {
            throw new NotImplementedException();
        }

        #endregion

        // Part 2: Images

        #region GetImage

        static async Task GetImage()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ListImagesLimit

        static async Task ListImagesLimit(int count)
        {
            throw new NotImplementedException();
        }

        #endregion

        // Part 3: Breed images

        #region GetBreedImage

        static async Task GetBreedImage(string breed)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ListBreedImages

        static async Task ListBreedImages(string breed)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ListBreedImagesLimit

        static async Task ListBreedImagesLimit(string breed, int count)
        {
            throw new NotImplementedException();
        }

        #endregion

        // Part 4: Sub-breed images

        #region GetSubBreedImage

        static async Task GetSubBreedImage(string breed, string subBreed)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ListSubBreedImages

        static async Task ListSubBreedImages(string breed, string subBreed)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ListSubBreedImagesLimit

        static async Task ListSubBreedImagesLimit(string breed, string subBreed, int count)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
