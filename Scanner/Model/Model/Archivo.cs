namespace Model
{
    // Clase Archivo, representando el archivo a procesar
    public class Archivo
    {
        public string Nombre { get; set; }
        public Archivo(string nombre)
        {
            Nombre = nombre;
        }

        public int ObtenerTamanoEnKb()
        {
            FileInfo info = new FileInfo(Nombre);
            return (int)(info.Length / 1024); // Retorna el tamaño en KB
        }

        // Método para contar vocales en el nombre del archivo
        public int ContarVocalesEnNombre()
        {
            return Nombre.Count(c => "aeiouAEIOU".Contains(c));
        }
    }

}

