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
        private List<Zocalo> historial = new List<Zocalo>();

        // Método para agregar entrada al historial
        public void AgregarEntrada(Zocalo zocalo)
        {
            historial.Add((zocalo));
        }
        public Zocalo obtenerZocalo(int tamano) { 

            return historial.Where(z=>z.PerteneceAlZocalo(tamano)).FirstOrDefault();

        }

        // Método para imprimir el historial
        public void ImprimirHistorial()
        {
            Console.WriteLine("Historial de duraciones por zócalo:");

            historial.ForEach(z => Console.WriteLine($"Zócalo: {z.MinTamano} - {z.MaxTamano} KB, Duración Promedio: {z.PromedioDuracion} segundos y tamano Promedio: {z.PromedioTamañoArchivos} kb"));
    
        }
    }
}
