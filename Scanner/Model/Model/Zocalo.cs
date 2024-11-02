namespace Model
{
    // Clase Zocalo, representando un rango de tamaño de archivos
    public class Zocalo
    {
        public long Id { get; set; }
        public int MinTamano { get; private set; }
        public int MaxTamano { get; private set; }
        public double PromedioDuracion { get; set; }
        public double PromedioTamañoArchivos { get; set; } // Cambiar nombre a ZocaloIndice o similar
        public int CantidadArchivos { get; set; }

        public Zocalo()
        {

        }

        public void CalcularPromedio(long duracionTotalEnMilisegundos)
        {
            if (this.CantidadArchivos != 0)
            {
                this.PromedioDuracion = duracionTotalEnMilisegundos / this.CantidadArchivos;
            }
        }

        public Zocalo(long tamañoArchivo)
        {
            //this.MinTamano = (tamañoArchivo / 100) * 100; 
            //this.MaxTamano = tamañoInferior + 100; 
        }

        public Zocalo(int minTamano, int maxTamano)
        {
            MinTamano = minTamano;
            MaxTamano = maxTamano;
            PromedioDuracion = 0;
            PromedioTamañoArchivos = 0;
            CantidadArchivos = 0;
        }
        public Zocalo(int minTamano, int maxTamano, double promedioDuracion, double promedioTamañoArchivos, int cantidadArchivos)
        {
            MinTamano = minTamano;
            MaxTamano = maxTamano;
            PromedioDuracion = promedioDuracion;
            PromedioTamañoArchivos = promedioTamañoArchivos;
            CantidadArchivos = cantidadArchivos;
        }

        public void ActualizarPromedio(long tamano, int duracion)
        {
            CantidadArchivos++;
            // Calcular el nuevo promedio de duración
            PromedioDuracion = ((PromedioDuracion * (CantidadArchivos - 1)) + duracion) / CantidadArchivos;
            // Calcular el nuevo promedio de tamaño
            PromedioTamañoArchivos = ((PromedioTamañoArchivos * (CantidadArchivos - 1)) + tamano) / CantidadArchivos;
        }

        public bool PerteneceAlZocalo(int tamano)
        {
            return tamano >= MinTamano && tamano <= MaxTamano;
        }
    }
}