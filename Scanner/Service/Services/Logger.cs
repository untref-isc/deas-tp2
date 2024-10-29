namespace Service
{
    // Implementación de Logger como observador
    public class Logger : IObservador
    {
        private int estimado = 0;
        private int acumulado = 0;

        public Logger(int estimado)
        {
            this.estimado = estimado;
        }

        public void Actualizar(string nombreArchivo, int progreso)
        {
            acumulado += progreso;
            Console.WriteLine($"[Log] Progreso registrado: {nombreArchivo} - {acumulado}/{estimado}");
        }
    }

}

