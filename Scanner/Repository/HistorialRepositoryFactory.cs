namespace Repository
{
    public class HistorialRepositoryFactory
    {

        private static HistorialRepository? instanciaUnica;
        private static readonly object lockObject = new object();


        private HistorialRepositoryFactory() { }


        public static HistorialRepository ObtenerHistorialRepository()
        {

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