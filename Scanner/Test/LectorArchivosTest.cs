using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service;

[TestClass]
public class LectoraArchivosTests
{
    [TestMethod]
    public void NotificarObservadores_LlamaActualizarDeCadaObservador()
    {
       
        var observadorMock = new Mock<IObservador>();
        var lectoraArchivos = new LectoraArchivos();
        lectoraArchivos.AnadirObservador(observadorMock.Object);

        
        lectoraArchivos.NotificarObservadores("archivo.txt", 50);

       
        observadorMock.Verify(o => o.Actualizar("archivo.txt", 50), Times.Once);
    }
}