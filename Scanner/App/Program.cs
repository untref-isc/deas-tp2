using Service;
using Service.Comando;
using Service.Services;
using System.IO;
using System.Text.RegularExpressions;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
           string ruta;
            if (!IntentaObtenerRuta(args, out ruta) )
                return;
         
            try
            {
                _=ShowAsync(ruta);
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.Message}");
            }

         
        }

       
        private static async Task ShowAsync(string directorio)
        {
            EscaneadorService.CoeficienteParaIndicarCuantoTardaEnLeerUnArchivo = 1;
            LectorArchivos lector = new LectorArchivos();

            try
            {
                lector.AgregarObservador(new UI());
            
                await lector.EjecutarComando(new ComandoEstimarDirectorio(directorio));
                await lector.EjecutarComando(new ComandoEscanearDirectorio(directorio));
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.Message}");
            }
        }

        static bool IntentaObtenerRuta(string[] args, out string ruta)
        {
            ruta = String.Empty;
            if (args.Length == 0)
            {
                Console.WriteLine("Por favor, ingrese una ruta como parámetro.");
                return false;
            }
            var rutaCandidata = args[0];

           string patronRuta = @"^[a-zA-Z]:(\\[a-zA-Z0-9._-]+)*\\?$";
            Regex regex = new Regex(patronRuta);

            if (!regex.IsMatch(rutaCandidata))
            {
                Console.WriteLine("La ruta '{0}' tiene un formato inválido.", rutaCandidata);
                return false;
            }

            ruta = rutaCandidata;
            return true;
        }

    }
}