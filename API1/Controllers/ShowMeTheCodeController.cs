using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace API1.Controllers
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

                return "https://github.com/brunojpv/API1.git";
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro na URL do GitHub da API1!!!");

                return "";
            }
        }        
    }
}
