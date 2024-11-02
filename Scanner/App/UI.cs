using Service;

namespace App
{
    // Implementación de la UI como observador
    public class UI : IObservador
    {
        private const int cantidadDeMensajesQueAgrupo = 200;
        private int acumulador;

        public void InformarFin(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public void InformarInicio(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public void InformarProgreso(string mensaje)
        {
            if (acumulador < cantidadDeMensajesQueAgrupo)
            {
                acumulador++;
            }
            else
            {
                Console.WriteLine(mensaje);
                acumulador = 0;
            }
        }
    }
}