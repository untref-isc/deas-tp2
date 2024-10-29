namespace Service
{
    // Implementación de la UI como observador
    public class UI : IObservador
    {
        public void Actualizar(string nombreArchivo, int duracion)
        {
            Console.WriteLine($"{nombreArchivo} Demora: {duracion}");
        }
    }

}

