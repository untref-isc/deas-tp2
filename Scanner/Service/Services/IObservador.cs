namespace Service
{
    // Definimos la interfaz del observador
    public interface IObservador
    {
        void Actualizar(string nombreArchivo, int progreso);
    }

}

