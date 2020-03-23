using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Repository;

namespace TDD
{
    [TestClass]
    public class TaxaJurosTest
    {
        [TestMethod]
        public void TestTaxaJuros()
        {
            decimal decToCompare = 0.01m;

            TaxaJurosService objTaxaJurosService = new TaxaJurosService(new TaxaJurosRepository());
            decimal decResultado = objTaxaJurosService.GetTaxaJuros().ValorTaxa;

            Assert.AreEqual(decToCompare, decResultado);
        }
    }
}
