using System.Threading.Tasks;

namespace API2.Services
{
    public interface IJurosService
    {
        Task<decimal> buscarJuros();
    }
}
