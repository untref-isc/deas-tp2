using Repository;
using Service.Modelo;
using Service.Services;
using Service.Utils;

namespace Service.Comando
{
    public class ComandoEscanearDirectorio : IComando
    {
        private readonly string directorio;
        private List<IObservador> observadores;
        private readonly EscaneadorService escaneadorService;
        private readonly EstimadorDuracionService estimadorDuracionService;

        public ComandoEscanearDirectorio(string directorio)
        {
            this.directorio = directorio;
            this.observadores = new List<IObservador>();
            this.escaneadorService = new EscaneadorService();
            this.estimadorDuracionService = new EstimadorDuracionService(HistorialRepositoryFactory.ObtenerHistorialRepository());
        }

        public async Task Ejecutar()
        {
            DirectorioRepository.AsegurarseDeQueExisteDirectorio(this.directorio);
            ResultadoEjecucion resultado = new ResultadoEjecucion();
            FileInfo[] archivos = DirectorioRepository.ObtenerArchivos(directorio);
            foreach (FileInfo archivo in archivos)
            {
                TimeSpan duracion = this.escaneadorService.Escanear(archivo);
                resultado.Agregar(archivo.GetSizeInKB(), duracion);
                this.observadores.ForEach(observador => observador.InformarProgreso($"Progreso registrado: {resultado.ObtenerCantidadDeEjecuciones()} de {archivos.Count()}"));
            }
            await this.estimadorDuracionService.GuardarInformacion(resultado.CalcularZocalos());
            this.observadores.ForEach(observador => observador.InformarFin($"El proceso termino correctamente. Tiempo de duración: {resultado.ObtenerTotalTiempo().ToString("N0")} milisegundos"));
        }

        public void AnadirObservador(IObservador observador)
        {
            this.observadores.Add(observador);
        }
    }
}