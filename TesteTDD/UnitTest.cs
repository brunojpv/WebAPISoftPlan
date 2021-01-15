using API2.Controllers;
using API2.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TesteTDD
{
    public class UnitTest
    {
        private readonly IJurosService _jurosService;
        private readonly ILogger<CalculaJurosController> _logger;

        public UnitTest()
        {
            var logger = new Mock<ILogger<CalculaJurosController>>();
            var jurosServiceMock = new Mock<IJurosService>();
            jurosServiceMock.Setup(a => a.buscarJuros()).Returns(Task.Run(() => 0.01M));
            _jurosService = jurosServiceMock.Object;
            _logger = logger.Object;
        }

        [Fact]
        public async Task Test()
        {
            // Arrange
            var controle = new CalculaJurosController(_logger, _jurosService);
            
            // Act
            var resp = await controle.GetCalculaJuros(100.00, 5);

            // Assert
            Assert.Equal(105.10M, resp);            
        }
    }
}
