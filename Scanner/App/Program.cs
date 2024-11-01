﻿using Model;
using Service;
using Service.Comando;
using Service.Services;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                _ = ShowAsync();
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.Message}%");
            }
        }

        private static async Task ShowAsync()
        {
            LectoraArchivos lector = new LectoraArchivos();
            string directorio = @"C:\flutter\"; // Cambia esta ruta por la correcta
            try
            {
                var files = FileScannerService.EstimacionejecucionRutaDirectorio(directorio); //Usar para estimar
                                                                                              // Agregar observadores
                lector.AnadirObservador(new UI());
                lector.AnadirObservador(new Logger((int)files.duracionTotal));

                string[] archivos = Directory.GetFiles(directorio);

                // Leer y procesar cada archivo en el directorio
                Console.WriteLine($"Duracion total  {files.duracionTotal}, cantidad de archivos {files.totalArchivos}");
                foreach (var nombreArchivo in archivos)
                {
                    Archivo archivo = new Archivo(nombreArchivo);
                    IComando comando = new ComandoLeerArchivo(archivo, lector);
                    lector.EjecutarComando(comando);
                }

                // Imprimir el historial de duraciones al final

                lector.ImprimirHistorial();
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.Message}%");
            }
        }
    }
}