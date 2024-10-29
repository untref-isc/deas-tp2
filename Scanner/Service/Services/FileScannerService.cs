﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FileScannerService
    {

        // Método que recibe un path y retorna el volumen (cantidad de archivos) y el tamaño total
        static public (int TotalArchivos, long TamanoTotal) EscanearDirectorio(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"El directorio '{path}' no existe.");
            }

            int totalArchivos = 0;
            long tamanoTotal = 0;

            // Escanea el directorio incluyendo los subdirectorios
            DirectoryInfo directorioInfo = new DirectoryInfo(path);
            FileInfo[] archivos = ObtenerArchivos(directorioInfo);

            // Cuenta archivos y suma tamaño
            foreach (var archivo in archivos)
            {
                totalArchivos++;
                tamanoTotal += archivo.Length;
            }

            return (totalArchivos, tamanoTotal);
        }

        // Método recursivo para obtener todos los archivos incluyendo subdirectorios
       static private FileInfo[] ObtenerArchivos(DirectoryInfo directorioInfo)
        {
            try
            {
                // Obtiene todos los archivos en el directorio actual
                FileInfo[] archivos = directorioInfo.GetFiles("*", SearchOption.AllDirectories);
                return archivos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al acceder al directorio: {directorioInfo.FullName}. {ex.Message}");
                return new FileInfo[0];
            }
        }

    }
}