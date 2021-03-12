using API1.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace API1.Controllers
{
    [Route("api/taxaJuros")]
    [ApiVersion("1")]
    [SwaggerGroup("Taxa de Juros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private static ILogger<TaxaJurosController> _logger;

        public TaxaJurosController(ILogger<TaxaJurosController> logger)
        {
            _logger = logger;
        }

        [HttpGet, MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public decimal TaxaJuros()
        {
            try
            {
                _logger.LogInformation("Taxa de juros enviada com sucesso!!!");

                return 0.01M;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro na taxa de juros!!!");

                return 0;
            }
        }
    }
}
