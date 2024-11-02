namespace Model
{
    public class Zocalo
    {
        public int Id { get; set; }
        public double PromedioDuracion { get; set; }
        public double PromedioTamañoArchivos { get; set; }
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
    }
}