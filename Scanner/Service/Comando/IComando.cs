namespace Service.Comando
{
    public interface IComando
    {
        Task Ejecutar();
        void AnadirObservador(IObservador observador);
    }
}