using Model;
using Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
            var zocalo =  ObtenerZocaloPorTamano(tamano);

            // Si no hay zócalo, creamos uno nuevo.
            if (zocalo != null)
            {
                zocalo.ActualizarPromedio(tamano, duracion);
            }
            else {
                zocalo = CrearZocalo(tamano);
                zocalo.ActualizarPromedio(tamano, duracion);
                _=historialRepository.AgregarEntrada(zocalo);
            }
        }

        // Crear un nuevo zócalo basándose en el tamaño del archivo
        private Zocalo CrearZocalo(int tamano)
        {
            int tamañoInferior = (tamano / 100) * 100; // Redondear hacia abajo a un múltiplo de 10
            int tamañoSuperior = tamañoInferior + 100; // Definir un tamaño superior para el nuevo zócalo

            return new Zocalo(tamañoInferior, tamañoSuperior);
        }

        private  Zocalo ObtenerZocaloPorTamano(int tamano)
        {       
            return  historialRepository.obtenerZocalo(tamano);
        }

        private  Zocalo? ObtenerZocaloCercanoPorTamano(int tamano)
        {
            return  historialRepository.obtenerZocaloCercano(tamano);
        }

        public  double ObtenerDuracionEstimada(int tamano)
        {
            var zocalo = ObtenerZocaloCercanoPorTamano(tamano);
            if (zocalo != null && zocalo?.CantidadArchivos > 0)
            {
                return (Math.Round(zocalo.PromedioDuracion, 2));
            }
            return 0;
        }

        // Método para imprimir el historial
        public void ImprimirHistorial()
        {
            historialRepository.ObtenerTodosAsync().Result.ForEach(z => Console.WriteLine($"Zócalo: {z.MinTamano} - {z.MaxTamano} KB, Duración Promedio: {z.PromedioDuracion} segundos y tamano Promedio: {z.PromedioTamañoArchivos} kb"));
        }
    }

}

