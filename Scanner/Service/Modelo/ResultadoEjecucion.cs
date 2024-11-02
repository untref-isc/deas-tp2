using Model;
using System.Collections.Generic;
using System.Linq;

namespace Service.Modelo
{
    public class ResultadoEjecucion
    {
        private List<ResultadoEjecucionItem> items;
        private const int ZOCALO_TAMAÑO_ARCHIVO = 100;

        public ResultadoEjecucion()
        {
            this.items = new List<ResultadoEjecucionItem>();
        }

        internal void Agregar(long tamañoArchivo, TimeSpan duracionTotal)
        {
            this.items.Add(new ResultadoEjecucionItem(tamañoArchivo, (int)duracionTotal.TotalMilliseconds));
        }

        internal List<Zocalo> CalcularMetricas()
        {
            List<Zocalo> zocalos = new List<Zocalo>();

            for (long zocaloIndice = this.ObtenerMenorTamaño(); zocaloIndice <= this.ObtenerMayorTamaño(); zocaloIndice += ZOCALO_TAMAÑO_ARCHIVO)
            {
                long siguienteZocaloIndice = zocaloIndice + ZOCALO_TAMAÑO_ARCHIVO;
                IEnumerable<ResultadoEjecucionItem> zocaloItems = this.items.Where(x => x.TamañoArchivo >= zocaloIndice && x.TamañoArchivo < siguienteZocaloIndice);
                if (zocaloItems.Any())
                {
                    Zocalo zocalo = new Zocalo();
                    zocalo.CantidadArchivos = zocaloItems.Count();
                    zocalo.PromedioTamañoArchivos = siguienteZocaloIndice;
                    zocalo.CalcularPromedio(zocaloItems.Sum(x => x.DuracionTotalEnMilisegundos));
                    zocalos.Add(zocalo);
                }
            }
            return zocalos;
        }

        internal int ObtenerTotalTiempo()
        {
            return this.items.Sum(x => x.DuracionTotalEnMilisegundos);
        }

        public int ObtenerCantidadDeEjecuciones()
        {
            return this.items.Count();
        }

        private long ObtenerMenorTamaño()
        {
            return this.items.OrderBy(x => x.TamañoArchivo).First().TamañoArchivo;
        }

        private long ObtenerMayorTamaño()
        {
            return this.items.OrderByDescending(x => x.TamañoArchivo).First().TamañoArchivo;
        }
    }

    public class ResultadoEjecucionItem
    {
        public ResultadoEjecucionItem(long tamañoArchivo, int duracionTotal)
        {
            this.DuracionTotalEnMilisegundos = duracionTotal;
            this.TamañoArchivo = tamañoArchivo;
        }

        public int DuracionTotalEnMilisegundos { get; set; }
        public long TamañoArchivo { get; set; }
    }
}