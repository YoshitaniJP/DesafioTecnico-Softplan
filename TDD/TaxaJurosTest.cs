using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD
{
    [TestClass]
    public class TaxaJurosTest
    {
        [TestMethod]
        public void TestTaxaJuros()
        {
            decimal decToCompare = 0.01m;

            TaxaJurosService objTaxaJurosService = new TaxaJurosService();
            decimal decResultado = objTaxaJurosService.GetTaxaJuros();

            Assert.AreEqual(decToCompare, decResultado);
        }
    }
}
