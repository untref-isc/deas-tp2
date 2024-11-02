using Service;

namespace App
{
    public class Logger : IObservador
    {
        private int estimado = 0;
        private int acumulado = 0;

        public Logger()
        {
            //this.estimado = estimado;
        }

        public void InformarFin(string mensaje)
        {
            //throw new NotImplementedException();
        }

        public void InformarInicio(string mensaje)
        {
            //throw new NotImplementedException();
        }

        public void InformarProgreso(string mensaje)
        {
            //acumulado += progreso;
            //Console.WriteLine($"[Log] Progreso registrado: {nombreArchivo} - {acumulado}/{estimado}");
        }
    }
}