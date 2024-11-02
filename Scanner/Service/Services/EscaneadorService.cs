namespace Service.Services
{
    public class EscaneadorService
    {
        public TimeSpan Escanear(FileInfo archivo)
        {
            DateTime inicio = DateTime.Now;
            File.ReadAllBytes(archivo.FullName);
            File.ReadAllBytes(archivo.FullName);
            File.ReadAllBytes(archivo.FullName);
            File.ReadAllBytes(archivo.FullName);
            File.ReadAllBytes(archivo.FullName);
            File.ReadAllBytes(archivo.FullName);
            return (DateTime.Now - inicio) * CoeficienteParaIndicarCuantoTardaEnLeerUnArchivo;
        }

        public static double CoeficienteParaIndicarCuantoTardaEnLeerUnArchivo { get; set; }
    }
}