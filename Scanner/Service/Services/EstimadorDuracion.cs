using Model;
using Repository;
namespace Service

{

    public class EstimadorDuracion
    {
        private HistorialRepository historialRepository;

        public EstimadorDuracion(HistorialRepository historialRepository)
        {
            this.historialRepository = historialRepository;
        }

        public void RegistrarDuracion(string nombreArchivo, int tamano, int duracion)
        {
            Zocalo zocalo = ObtenerZocaloPorTamano(tamano);

            // Si no hay zócalo, creamos uno nuevo.
            if (zocalo != null)
            {
                zocalo.ActualizarPromedio(tamano, duracion);
            }
            else {
                zocalo = CrearZocalo(tamano);
                zocalo.ActualizarPromedio(tamano, duracion);
                historialRepository.AgregarEntrada(zocalo);
            }
        }

        // Crear un nuevo zócalo basándose en el tamaño del archivo
        private Zocalo CrearZocalo(int tamano)
        {
            int tamañoInferior = (tamano / 100) * 100; // Redondear hacia abajo a un múltiplo de 10
            int tamañoSuperior = tamañoInferior + 100; // Definir un tamaño superior para el nuevo zócalo

            return new Zocalo(tamañoInferior, tamañoSuperior);
        }

        private Zocalo ObtenerZocaloPorTamano(int tamano)
        {
            return historialRepository.obtenerZocalo(tamano);
        }

        public int ObtenerDuracionEstimada(int tamano)
        {
            Zocalo zocalo = ObtenerZocaloPorTamano(tamano);
            if (zocalo != null && zocalo.CantidadArchivos > 0)
            {
                return ((int)zocalo.PromedioDuracion);
            }
            return -1;
        }

        // Método para imprimir el historial
        public void ImprimirHistorial()
        {
            historialRepository.ImprimirHistorial();
        }
    }

}

