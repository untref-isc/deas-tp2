using Repository;
using Service.Comando;

namespace Service
{
    // Clase LectoraArchivos (sujeto que notifica a los observadores)
    public class LectoraArchivos
    {
        private List<IObservador> observadores = new List<IObservador>();
        private EstimadorDuracion estimador = new EstimadorDuracion(HistorialRepositoryFactory.ObtenerHistorialRepository());

        public void AnadirObservador(IObservador observador)
        {
            observadores.Add(observador);
        }

        public void NotificarObservadores(string nombreArchivo, int progreso)
        {
            foreach (var observador in observadores)
            {
                observador.Actualizar(nombreArchivo, progreso);
            }
        }

        public void EjecutarComando(IComando comando)
        {
            comando.Ejecutar();
        }

        // Método para registrar la duración en el estimador
        public void RegistrarDuracion(string nombreArchivo, int tamano, int duracion)
        {
            estimador.RegistrarDuracion(nombreArchivo, tamano, duracion);
        }

        // Método para imprimir el historial
        public void ImprimirHistorial()
        {
            estimador.ImprimirHistorial();
        }
    }

}