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