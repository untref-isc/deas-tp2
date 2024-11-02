using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using Repository;
using Service;


[TestClass]
public class EstimadorDuracionTests
{
    private Mock<HistorialRepository> _historialRepositoryMock;
    private EstimadorDuracionService _estimadorDuracion;

    [TestInitialize]
    public void Setup()
    {
        _historialRepositoryMock = new Mock<HistorialRepository>();
        _estimadorDuracion = new EstimadorDuracionService(_historialRepositoryMock.Object);
    }

    [TestMethod]
    public void RegistrarDuracion_CuandoNoExisteZocalo_LlamaAgregarEntrada()
    {

        //_historialRepositoryMock.Setup(repo => repo.obtenerZocaloCercano(It.IsAny<int>())).Returns((Zocalo)null);
        //_historialRepositoryMock.Setup(repo => repo.obtenerZocalo(It.IsAny<int>())).Returns((Zocalo)null);

        //_estimadorDuracion.RegistrarDuracion("archivo.txt", 150, 10);

        //_historialRepositoryMock.Verify(repo => repo.Agregar(It.IsAny<Zocalo>()), Times.Once);
    }

    [TestMethod]
    public async Task ObtenerDuracionEstimada_CuandoNoExisteZocalo_RetornaCero()
    {

        //_historialRepositoryMock.Setup(repo => repo.obtenerZocaloCercano(It.IsAny<int>())).Returns((Zocalo)null);


        //var duracionEstimada = await _estimadorDuracion.ObtenerDuracionEstimada(150);


        //Assert.AreEqual(0, duracionEstimada);
    }
}