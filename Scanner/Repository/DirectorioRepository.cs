using System.Text.RegularExpressions;

namespace Repository
{
    public class DirectorioRepository
    {
        public static FileInfo[] ObtenerArchivos(string directorio)
        {
            return new DirectoryInfo(directorio)
                   .GetFiles("*", SearchOption.AllDirectories);
        }

        public static void AsegurarseDeQueExisteDirectorio(string directorio) 
        {
            if (!Directory.Exists(directorio))
            {
                throw new DirectoryNotFoundException($"El directorio '{directorio}' no existe.");
            }
        }

        private static bool esRutaVacia(string ruta)
        {
            AsegurarseDeQueExisteDirectorio(ruta);


            if (Directory.GetFiles(ruta).Length > 0)
            {
                return false;
            }


            foreach (string subDirectorio in Directory.GetDirectories(ruta))
            {
                if (!esRutaVacia(subDirectorio))
                {
                    return false;
                }
            }
            return true;
        }

    }
}