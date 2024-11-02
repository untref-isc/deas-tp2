using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class HistorialRepository
    {
        private const int TOLERANCIA_TAMAÑO_ZOCALO = 100;

        public async Task BorrarDatos()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                await context.Zocalos.ExecuteDeleteAsync();
            }
        }

        public virtual async Task<int> Agregar(List<Zocalo> zocalos)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                await context.Zocalos.AddRangeAsync(zocalos);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<List<Zocalo>> ObtenerTodos()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return await context.Zocalos.ToListAsync();
            }
        }
    }
}