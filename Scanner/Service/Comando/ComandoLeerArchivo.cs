using Model;

namespace Service.Comando
{
    // Implementación del Comando para leer archivos
    public class ComandoLeerArchivo : IComando
    {
        private Archivo archivo;
        private LectoraArchivos lector;

        public ComandoLeerArchivo(Archivo archivo, LectoraArchivos lector)
        {
            this.archivo = archivo;
            this.lector = lector;
        }

        public void Ejecutar()
        {
            int tamanoArchivo = archivo.ObtenerTamanoEnKb();
                        
            // Contar vocales en el nombre del archivo
            int vocales = archivo.ContarVocalesEnNombre();

            if (vocales == 0)
            {
                Console.WriteLine($"El archivo {archivo.Nombre} no tiene vocales en su nombre.");
                return;
            }
            DateTime inicio = DateTime.Now;

            // Simulación de procesamiento de vocales con un delay de 1 segundo por vocal
            for (int i = 1; i <= vocales; i++)
            {
                Thread.Sleep(1000); // Simula la demora de 1 segundo por vocal
                int progreso = (i * 100) / vocales;
            }

            // Registro de la duración real de la tarea
            TimeSpan duracionReal = DateTime.Now - inicio;
            int duracionRealSegundos = ((int)duracionReal.TotalSeconds);
            lector.NotificarObservadores(archivo.Nombre,duracionRealSegundos);
            lector.RegistrarDuracion(archivo.Nombre, tamanoArchivo, duracionRealSegundos); // Registrar en el lector
        }
    }

}

