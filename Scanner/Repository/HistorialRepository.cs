using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HistorialRepository
    {
        private List<Zocalo> historial = new List<Zocalo>() {
          new (0, 100,5.461, 15.76, 1),
          new (100, 200,4, 140, 1),
          new (800, 900,2, 884, 1),
          new (1700, 1800,5, 1769, 1),
          new (2600, 2700,5, 2653, 1)

        };

        // Método para agregar entrada al historial
        public void AgregarEntrada(Zocalo zocalo)
        {
            historial.Add((zocalo));
        }
        public Zocalo obtenerZocalo(int tamano) { 

            return historial.Where(z=>z.PerteneceAlZocalo(tamano)).FirstOrDefault();

        }
        public Zocalo obtenerZocaloCercano(int tamano)
        {
            Zocalo coincidenciaExacta = obtenerZocalo(tamano);
            if (coincidenciaExacta != null) return coincidenciaExacta;

            Zocalo masCercanoSuperior = historial
                .Where(z => z.MinTamano >= tamano)
                .OrderBy(z => z.MinTamano)
                .FirstOrDefault();

            Zocalo masCercanoIngferior =  historial.Where(z => z.MaxTamano <= tamano)
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
        private double promediar(double valor1, double valor2)
        {
            return (valor1 + valor2) / 2;
        }

        // Método para imprimir el historial
        public void ImprimirHistorial()
        {
            Console.WriteLine("Historial de duraciones por zócalo:");

            historial.ForEach(z => Console.WriteLine($"Zócalo: {z.MinTamano} - {z.MaxTamano} KB, Duración Promedio: {z.PromedioDuracion} segundos y tamano Promedio: {z.PromedioTamañoArchivos} kb"));
    
        }
    }
}
