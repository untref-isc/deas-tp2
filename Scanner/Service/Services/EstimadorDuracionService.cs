using Model;
using Repository;

namespace Service
{
    public class EstimadorDuracionService
    {
        private HistorialRepository historialRepository;

        public EstimadorDuracionService(HistorialRepository historialRepository)
        {
            this.historialRepository = historialRepository;
        }

        public void RegistrarDuracion(string nombreArchivo, int tamano, int duracion)
        {
            Zocalo? zocalo = ObtenerZocaloPorTamano(tamano);

            // Si no hay zócalo, creamos uno nuevo.
            if (zocalo != null)
            {
                zocalo.ActualizarPromedio(tamano, duracion);
            }
            else
            {
                zocalo = new Zocalo(tamano);
                zocalo.ActualizarPromedio(tamano, duracion);
                _ = historialRepository.Agregar(zocalo);
            }
        }

        private Zocalo? ObtenerZocaloPorTamano(int tamano)
        {
            return historialRepository.obtenerZocalo(tamano);
        }

        private async Task<Zocalo> ObtenerZocaloCercanoPorTamanoOCrearlo(long tamano)
        {
            Zocalo? zocalo = historialRepository.obtenerZocaloCercano(tamano);
            if (zocalo is null)
            {
                zocalo = new Zocalo(0, 0);
                await historialRepository.Agregar(zocalo);
            }
            return zocalo;
        }

        public async Task<double> ObtenerDuracionEstimada(long tamano)
        {
            var zocalo = await ObtenerZocaloCercanoPorTamanoOCrearlo(tamano);

            if (zocalo.CantidadArchivos > 0)
            {
                return (Math.Round(zocalo.PromedioDuracion, 2));
            }
            return 0;
        }

        // Método para imprimir el historial
        public void ImprimirHistorial()
        {
            historialRepository.ObtenerTodos().Result.ForEach(z => Console.WriteLine($"Zócalo: {z.MinTamano} - {z.MaxTamano} KB, Duración Promedio: {z.PromedioDuracion} segundos y tamano Promedio: {z.PromedioTamañoArchivos} kb"));
        }

        public async Task GuardarInformacion(List<Zocalo> zocalos)
        {
            await this.historialRepository.BorrarDatos();
            await this.historialRepository.Agregar(zocalos);
        }

        public async Task<List<Zocalo>> ObtenerHistorialEstimaciones()
        {
            return await this.historialRepository.ObtenerTodos();
        }

        internal async Task<bool> HayEstimacionesExistentes()
        {
            var list = await this.historialRepository.ObtenerTodos();
            return list.Any();
        }
    }
}