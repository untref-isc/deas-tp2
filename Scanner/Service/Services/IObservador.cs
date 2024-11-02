namespace Service
{
    public interface IObservador
    {
        void InformarProgreso(string mensaje);
        void InformarInicio(string mensaje);
        void InformarFin(string mensaje);
    }
}