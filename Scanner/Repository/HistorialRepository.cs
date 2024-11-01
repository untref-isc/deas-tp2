using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class HistorialRepository
    {

        // Método para agregar entrada al historial
        public virtual async Task<int> AgregarEntrada(Zocalo zocalo)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.zocalos.Add(zocalo);
                return await context.SaveChangesAsync();
            }
        }
        public virtual Zocalo? obtenerZocalo(long tamano)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.zocalos.Where(z => tamano >= z.MinTamano && tamano <= z.MaxTamano).FirstOrDefault();
            }
        }
        public virtual Zocalo obtenerZocaloCercano(long tamano)
        {
            var coincidenciaExacta = obtenerZocalo(tamano);
            if (coincidenciaExacta != null) return coincidenciaExacta;
            using (ApplicationContext context = new ApplicationContext())
            {
                var masCercanoSuperior = context.zocalos
                    .Where(z => z.MinTamano >= tamano)
                    .OrderBy(z => z.MinTamano)
                    .FirstOrDefault();

                var masCercanoIngferior = context.zocalos
                    .Where(z => z.MaxTamano <= tamano)
                    .OrderByDescending(z => z.MaxTamano)
                    .FirstOrDefault();

                if (masCercanoIngferior != null && masCercanoSuperior != null)
                    return new Zocalo(masCercanoIngferior.MaxTamano,
                        masCercanoSuperior.MinTamano,
                        promediar(masCercanoIngferior.PromedioDuracion, masCercanoSuperior.PromedioDuracion),
                        promediar(masCercanoIngferior.PromedioTamañoArchivos,
                        masCercanoSuperior.PromedioTamañoArchivos),
                        1);

                if (masCercanoSuperior != null) return masCercanoSuperior;

                return masCercanoIngferior;
            }
        }
        private double promediar(double valor1, double valor2)
        {
            return (valor1 + valor2) / 2;
        }

        public async Task<List<Zocalo>> ObtenerTodosAsync()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return await context.zocalos.ToListAsync();
            }
        }
    }
}