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
            return DateTime.Now - inicio;
        }

        public static int CoeficienteParaIndicarCuantoTardaEnLeerUnArchivo { get; set; }
    }
}