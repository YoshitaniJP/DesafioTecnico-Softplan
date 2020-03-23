using Domain.Interfaces;
using Domain.Models;
using Domain.Repository;

namespace Domain.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private TaxaJurosRepository taxaJurosRepository;

        public TaxaJurosService(TaxaJurosRepository _taxaJurosRepository)
        {
            taxaJurosRepository = _taxaJurosRepository;
        }

        public TaxaJuros GetTaxaJuros()
        {
            TaxaJuros objTaxaJuros = taxaJurosRepository.GetFirstOrDefault();
            return objTaxaJuros;
        }
    }
}
