using Domain.Interfaces;

namespace Domain.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        public decimal GetTaxaJuros()
        {
            decimal decTaxaJuros = 0.01m;
            return decTaxaJuros;
        }
    }
}
