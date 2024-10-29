namespace Model
{
    // Clase Zocalo, representando un rango de tamaño de archivos
    public class Zocalo
    {
        public int MinTamano { get; private set; }
        public int MaxTamano { get; private set; }
        public double PromedioDuracion { get; private set; }
        public double PromedioTamañoArchivos { get; private set; }
        public int CantidadArchivos { get; private set; }

        public Zocalo(int minTamano, int maxTamano)
        {
            MinTamano = minTamano;
            MaxTamano = maxTamano;
            PromedioDuracion = 0;
            PromedioTamañoArchivos = 0;
            CantidadArchivos = 0;
        }

        public void ActualizarPromedio(long tamano,int duracion)
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

