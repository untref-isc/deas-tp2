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

        public virtual async Task<int> Actualizar(Zocalo zocalo)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Zocalos.Update(zocalo);
                return await context.SaveChangesAsync();
            }
        }

        public virtual async Task<int> Agregar(Zocalo zocalo)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Zocalos.Add(zocalo);
                return await context.SaveChangesAsync();
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

        public async Task<bool> Existe(Zocalo zocalo)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return await context.Zocalos.AnyAsync(x => x.PromedioTamañoArchivos == zocalo.PromedioTamañoArchivos);
            }
        }

        public virtual Zocalo? obtenerZocalo(long tamanoArchivo)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Zocalos.Where(z => tamanoArchivo >= z.MinTamano && tamanoArchivo <= z.MaxTamano).FirstOrDefault();
            }
        }

        public Zocalo? obtenerZocaloCercano(long tamanoArchivo)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Zocalos
                    .Where(x => x.MinTamano >= tamanoArchivo)
                    .Where(x => x.MaxTamano < tamanoArchivo)
                    .FirstOrDefault();
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