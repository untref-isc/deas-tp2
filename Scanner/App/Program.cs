using Service;
using Service.Comando;
using Service.Services;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = ShowAsync();
        }

        private static async Task ShowAsync()
        {
            EscaneadorService.CoeficienteParaIndicarCuantoTardaEnLeerUnArchivo = 1;
            LectorArchivos lector = new LectorArchivos();
            string directorio = @"C:\prueba-untref\"; // Cambia esta ruta por la correcta
            try
            {
                lector.AgregarObservador(new UI());
                lector.AgregarObservador(new Logger());
                await lector.EjecutarComando(new ComandoEstimarDirectorio(directorio));
                await lector.EjecutarComando(new ComandoEscanearDirectorio(directorio));
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.Message}%");
            }
        }
    }
}