using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICalculaJurosService
    {
        Task<decimal> CalcularJuros(CalculaJuros objCalculaJuros);
        Task<decimal> GetTaxaJuros();
    }
}
