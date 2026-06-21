namespace EspacioTareas
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class Tarea
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task ObtenerTareas()
        {
            await ObtenerTareasAsync();
        }
        private static async Task ObtenerTareasAsync()
        {
            var url = "https://jsonplaceholder.typicode.com/todos";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);
            foreach (var tarea in tareas)
            {
                Console.WriteLine($"ID: {tarea.Id}, Title: {tarea.Title}, Completed: {tarea.Completed}");
            }
        }

    }

}