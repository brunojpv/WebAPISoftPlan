using API2.Common.Extensions;
using API2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API2.Controllers
{
    [ApiVersion("1")]
    [SwaggerGroup("Calculo de Juros")]
    [ApiController, Route("api/v{version:apiVersion}/calculajuros"), Produces("application/json")]
    public class CalculaJurosController : ControllerBase
    {
        private static ILogger<CalculaJurosController> _logger;
        private readonly IJurosService _jurosService;

        public CalculaJurosController(ILogger<CalculaJurosController> logger, IJurosService jurosService)
        {
            _logger = logger;
            _jurosService = jurosService;
        }

        [HttpGet("showmethecode"), MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string ShowMeTheCode()
        {
            try
            {
                _logger.LogInformation("URL do GitHub enviada com sucesso!!!");

                return "https://github.com/brunojpv/WebAPISoftPlan.git";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro na URL do GitHub da API2!!!");

                return "";
            }
        }

        [HttpPost("calculajuros"), MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<decimal> CalculaJuros(double valorInicial, int tempo)
        {
            try
            {
                decimal juros = await _jurosService.buscarJuros();

                decimal valorFinal = Decimal.Round(Convert.ToDecimal(valorInicial * Math.Pow(1 + Convert.ToDouble(juros), tempo)), 2);

                _logger.LogInformation("Calculo de juros executado com sucesso!!!");

                return valorFinal;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Erro no calculo de juros!!!");

                return 0;
            }
        }
    }
}
