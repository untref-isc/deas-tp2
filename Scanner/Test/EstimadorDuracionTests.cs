using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using Repository;
using Service;

[TestClass]
public class EstimadorDuracionTests
{
    private Mock<HistorialRepository> _historialRepositoryMock;
    private EstimadorDuracion _estimadorDuracion;

    [TestInitialize]
    public void Setup()
    {
        _historialRepositoryMock = new Mock<HistorialRepository>();
        _estimadorDuracion = new EstimadorDuracion(_historialRepositoryMock.Object);
    }

    [TestMethod]
    public void RegistrarDuracion_CuandoNoExisteZocalo_LlamaAgregarEntrada()
    {
        
        _historialRepositoryMock.Setup(repo => repo.obtenerZocaloCercano(It.IsAny<int>())).Returns((Zocalo)null);

        
        _estimadorDuracion.RegistrarDuracion("archivo.txt", 150, 10);

       
        _historialRepositoryMock.Verify(repo => repo.AgregarEntrada(It.IsAny<Zocalo>()), Times.Once);
    }

    [TestMethod]
    public void ObtenerDuracionEstimada_CuandoNoExisteZocalo_RetornaCero()
    {
        
        _historialRepositoryMock.Setup(repo => repo.obtenerZocaloCercano(It.IsAny<int>())).Returns((Zocalo)null);

        
        var duracionEstimada = _estimadorDuracion.ObtenerDuracionEstimada(150);

       
        Assert.AreEqual(0, duracionEstimada);
    }
}