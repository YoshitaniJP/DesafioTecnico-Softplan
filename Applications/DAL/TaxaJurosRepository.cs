using Domain.DAL;
using Domain.Models;
using System.Linq;

namespace Domain.Repository
{
    public class TaxaJurosRepository
    {
        public TaxaJurosRepository()
        {
            using (var context = new TaxaJurosContext())
            {
                TaxaJuros objTaxaJuros = context.TaxaJuros.FirstOrDefault(x => x.Id == 1);
                if (objTaxaJuros == null)
                {
                    context.TaxaJuros.Add(new TaxaJuros()
                    {
                        Id = 1,
                        ValorTaxa = 0.01m
                    });

                    context.SaveChanges();
                }
            }
        }

        public TaxaJuros GetFirstOrDefault()
        {
            using (var context = new TaxaJurosContext())
            {
                return context.TaxaJuros.FirstOrDefault();
            }
        }
    }
}
