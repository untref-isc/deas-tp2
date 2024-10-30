using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Services;
using System.IO;

[TestClass]
public class FileScannerServiceTests
{
    [TestMethod]
    [ExpectedException(typeof(DirectoryNotFoundException))]
    public void EscanearDirectorio_DirectorioInexistente_LanzaExcepcion()
    {
        FileScannerService.EstimacionejecucionRutaDirectorio("ruta/inexistente");
    }

    [TestMethod]
    public void EscanearDirectorio_ConArchivos_RetornaTotales()
    {
       
        string path = Path.Combine(Directory.GetCurrentDirectory(), "DirectorioPrueba");
        Directory.CreateDirectory(path);
        File.WriteAllText(Path.Combine(path, "archivo1.txt"), "Contenido de prueba");

        try
        {
            
            var resultado = FileScannerService.EstimacionejecucionRutaDirectorio(path);

            
            Assert.AreEqual(1, resultado.totalArchivos);
            Assert.IsTrue(resultado.duracionTotal > 0);
        }
        finally
        {
            Directory.Delete(path, true);
        }
    }
}