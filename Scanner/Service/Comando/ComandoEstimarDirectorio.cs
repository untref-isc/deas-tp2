using Model;
using Repository;
using Service.Services;
using Service.Utils;

namespace Service.Comando
{
    public class ComandoEstimarDirectorio : IComando
    {
        private readonly string directorio;
        private readonly List<IObservador> observadores;
        private const int CANTIDAD_DIRECTORIOS_PARA_ESTIMAR = 10;
        private EstimadorDuracionService estimadorDuracionService;
        private FileInfo[] archivos;
        private EscaneadorService escaneadorService;

        public ComandoEstimarDirectorio(string directorio)
        {
            this.directorio = directorio;
            this.observadores = new List<IObservador>();
            this.escaneadorService = new EscaneadorService();
            this.estimadorDuracionService = new EstimadorDuracionService(HistorialRepositoryFactory.ObtenerHistorialRepository());
        }

        public async Task Ejecutar()
        {
            DirectorioRepository.AsegurarseDeQueExisteDirectorio(this.directorio);
            var estimador = new EstimadorDuracionService(HistorialRepositoryFactory.ObtenerHistorialRepository());

            this.archivos = DirectorioRepository.ObtenerArchivos(directorio);

            double duracionTotal = 0;

            this.observadores.ForEach(observador => observador.InformarInicio("Iniciando proceso de estimación"));

            if (await this.estimadorDuracionService.HayEstimacionesExistentes())
            {
                duracionTotal = await this.EstimarUsandoHistorial();
            }

            if (duracionTotal == 0)
            {
                this.observadores.ForEach(observador => observador.InformarFin("No hay datos suficientes para hacer una estimacion"));
            }
            else
            {
                this.observadores.ForEach(observador => observador.InformarFin($"La estimación es de {duracionTotal.ToString("N0")} milisegundos"));
            }
        }

        public void AnadirObservador(IObservador observador)
        {
            this.observadores.Add(observador);
        }

        private async Task<double> EstimarUsandoHistorial()
        {
            double tiempo = 0;
            List<Zocalo> zocalos = await this.estimadorDuracionService.ObtenerHistorialEstimaciones();
            tiempo += zocalos.First().PromedioDuracion * this.ContarArchivosDelPrimerZocalo(zocalos.First());

            for (int i = 1; i < zocalos.Count - 1; i++)
            {
                tiempo += zocalos[i].PromedioDuracion * this.ContarArchivosDentroDelZocalo(zocalos[i - 1], zocalos[i]);
            }

            tiempo += zocalos.Last().PromedioDuracion * this.ContarArchivosDelUltimoZocalo(zocalos.Last());
            return tiempo;
        }

        private int ContarArchivosDelPrimerZocalo(Zocalo zocalo)
        {
            return this.archivos.Count(x => x.GetSizeInKB() <= zocalo.PromedioTamañoArchivos);
        }

        private int ContarArchivosDentroDelZocalo(Zocalo zocaloAnterior, Zocalo zocalo)
        {
            return this.archivos.Count(x => x.GetSizeInKB() > zocaloAnterior.PromedioTamañoArchivos &&
                x.GetSizeInKB() <= zocalo.PromedioTamañoArchivos);
        }

        private int ContarArchivosDelUltimoZocalo(Zocalo zocalo)
        {
            return this.archivos.Count(x => x.GetSizeInKB() > zocalo.PromedioTamañoArchivos);
        }
    }
}