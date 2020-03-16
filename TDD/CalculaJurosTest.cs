using Api2.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace TDD
{
    [TestClass]
    public class CalculaJurosTest
    {
        [TestMethod]
        public async Task TestCalculaJuros()
        {
            decimal decValorInicial = 100m;
            int intMeses = 5;
            decimal decToCompare = 105.10m;

            CalculaJurosService objCalculaJurosService = new CalculaJurosService(new HttpClient() { BaseAddress = new System.Uri("http://localhost:44312") });
            decimal decResultado = await objCalculaJurosService.CalcularJuros(decValorInicial, intMeses);

            Assert.AreEqual(decToCompare, decResultado);
        }
    }
}
