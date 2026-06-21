namespace EspacioTareas
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.IO;
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

        public static async Task<List<Tarea>> ObtenerTareas()
        {
            return await ObtenerTareasAsync();
        }
        private static async Task<List<Tarea>> ObtenerTareasAsync()
        {
            var url = "https://jsonplaceholder.typicode.com/todos";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);
            Console.WriteLine("----------------Tareas Pendientes----------------");
            foreach (var tarea in tareas)
            {
                if (!tarea.Completed)
                {
                    Console.WriteLine($"Title: {tarea.Title}, Completed: {tarea.Completed}");
                }
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("----------------Tareas Completadas");
            foreach (var tarea in tareas)
            {
                if (tarea.Completed)
                {
                    Console.WriteLine($"Title: {tarea.Title}, Completed: {tarea.Completed}");
                }
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
            return tareas;
        }
        public static async Task<bool> GuardarTareasEnArchivo(List<Tarea> tareas)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(tareas);
                string filePath = Directory.GetCurrentDirectory() + "/tareas.json";
                Console.WriteLine($"Guardando tareas en el archivo: {filePath}");
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"Tareas guardadas en el archivo: {filePath}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar las tareas en el archivo: {ex.Message}");
                return false;
            }
        }

    }

}