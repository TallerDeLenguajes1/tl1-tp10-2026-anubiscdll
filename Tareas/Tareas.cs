namespace EspacioTareas
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class Flags
    {
        [JsonPropertyName("nsfw")]
        public bool Nsfw { get; set; }

        [JsonPropertyName("religious")]
        public bool Religious { get; set; }

        [JsonPropertyName("political")]
        public bool Political { get; set; }

        [JsonPropertyName("racist")]
        public bool Racist { get; set; }

        [JsonPropertyName("sexist")]
        public bool Sexist { get; set; }

        [JsonPropertyName("explicit")]
        public bool Explicit { get; set; }
    }
    public class Tareas
    {
        // https://v2.jokeapi.dev/joke/
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("joke")]
        public string Joke { get; set; }

        [JsonPropertyName("flags")]
        public Flags Flags { get; set; }

        [JsonPropertyName("safe")]
        public bool Safe { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        private static readonly HttpClient client = new HttpClient();
        public static async Task ObtenerChiste()
        {
            Console.WriteLine("Obteniendo chiste...");
            await GetChiste();
        }
        private static async Task GetChiste()
        {
            var url = "https://v2.jokeapi.dev/joke/Programming?lang=es&type=single";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Tareas joke = JsonSerializer.Deserialize<Tareas>(responseBody);
            Console.WriteLine(joke.Joke);
        }
    }
}