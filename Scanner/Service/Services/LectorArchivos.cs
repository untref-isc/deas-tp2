using Repository;
using Service.Comando;

namespace Service
{
    public class LectorArchivos
    {
        private List<IObservador> observadores;
        private EstimadorDuracionService estimador;

        public LectorArchivos()
        {
            this.observadores = new List<IObservador>();
            this.estimador = new EstimadorDuracionService(HistorialRepositoryFactory.ObtenerHistorialRepository());
        }

        public void AgregarObservador(IObservador observador)
        {
            observadores.Add(observador);
        }

        public async Task EjecutarComando(IComando comando)
        {
            foreach (IObservador observador in observadores)
            {
                comando.AnadirObservador(observador);
            }

            await comando.Ejecutar();
        }
    }
}