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
    }
}