using EspacioTareas;
List<Tarea> Tareas = await Tarea.ObtenerTareas();
bool guardado = await Tarea.GuardarTareasEnArchivo(Tareas);
Console.WriteLine($"Tareas guardadas: {guardado}");
