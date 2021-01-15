using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private static ILogger<ShowMeTheCodeController> _logger;

        public ShowMeTheCodeController(ILogger<ShowMeTheCodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            try
            {
                _logger.LogInformation("URL do GitHub enviada com sucesso!!!");

                return "https://github.com/brunojpv/API2.git";
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro no calculo de juros!!!");

                return "Erro no calculo de juros!!!";
            }
        }        
    }
}
