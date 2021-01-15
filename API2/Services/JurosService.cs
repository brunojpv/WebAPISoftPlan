using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace API2.Services
{
    public class JurosService : IJurosService
    {
        private readonly Sites _sites;

        public JurosService(IConfiguration _conf)
        {
            _sites = _conf.GetSection("Sites").Get<Sites>();
        }

        public async Task<decimal> buscarJuros()
        {
            HttpClient client = new HttpClient();
            string resposta;
            
            HttpResponseMessage response = await client.GetAsync(_sites.Url);
            if (response.IsSuccessStatusCode)
            {
                resposta = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<decimal>(resposta);
            }
            else
                return 0;
        }
    }
}
