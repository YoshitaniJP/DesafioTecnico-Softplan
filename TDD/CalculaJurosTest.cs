using Domain.Services;
using Infra;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace TDD
{
    [TestClass]
    public class CalculaJurosTest
    {
        private HttpClient objClient;
        private readonly IOptions<Config> objConfig;

        public CalculaJurosTest()
        {
            objClient = new HttpClient() { BaseAddress = new System.Uri("http://localhost:5000") };
            objConfig = Options.Create<Config>(new Config { Url_ApiTaxaJuros = "http://localhost:5000/taxaJuros" });
        }

        [TestMethod]
        public async Task TestCalculaJuros()
        {
            decimal decValorInicial = 100m;
            int intMeses = 5;
            decimal decToCompare = 105.10m;

            CalculaJurosService objCalculaJurosService = new CalculaJurosService(objClient, objConfig);
            decimal decResultado = await objCalculaJurosService.CalcularJuros(decValorInicial, intMeses);

            Assert.AreEqual(decToCompare, decResultado);
        }
    }
}
