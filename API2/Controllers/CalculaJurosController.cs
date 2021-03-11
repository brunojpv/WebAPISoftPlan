using API2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API2.Controllers
{
    [Route("api/calculajuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private static ILogger<CalculaJurosController> _logger;
        private readonly IJurosService _jurosService;

        public CalculaJurosController(ILogger<CalculaJurosController> logger, IJurosService jurosService)
        {
            _logger = logger;
            _jurosService = jurosService;
        }

        [HttpGet]
        public async Task<decimal> GetCalculaJuros(double valorInicial, int tempo)
        {
            try
            {
                decimal juros = await _jurosService.buscarJuros();

                decimal valorFinal = Decimal.Round(Convert.ToDecimal(valorInicial * Math.Pow(1 + Convert.ToDouble(juros), tempo)), 2);

                _logger.LogInformation("Calculo de juros executado com sucesso!!!");

                return valorFinal;
            }
            catch(HttpRequestException ex)
            {
                _logger.LogError(ex, "Erro no calculo de juros!!!");

                return 0;
            }
        }
    }
}
