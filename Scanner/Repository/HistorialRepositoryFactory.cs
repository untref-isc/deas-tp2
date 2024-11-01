namespace Repository
{
    public class HistorialRepositoryFactory
    {
        // Instancia única de HistorialRepository
        private static HistorialRepository instanciaUnica;
        private static readonly object lockObject = new object();

        // Constructor privado para evitar la creación de instancias desde fuera
        private HistorialRepositoryFactory() { }

        // Método para obtener la instancia única de HistorialRepository
        public static HistorialRepository ObtenerHistorialRepository()
        {
            // Controla la creación en un entorno multithread
            if (instanciaUnica == null)
            {
                lock (lockObject)
                {
                    if (instanciaUnica == null)
                    {
                        instanciaUnica = new HistorialRepository();
                    }
                }
            }
            return instanciaUnica;
        }
    }
}