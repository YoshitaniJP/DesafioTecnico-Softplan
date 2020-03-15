using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api2.Services
{
    public class CalculaJurosService
    {
        private HttpClient objClient;

        public CalculaJurosService(HttpClient _objClient)
        {
            objClient = _objClient;
            objClient.DefaultRequestHeaders.Accept.Clear();
            objClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<decimal> CalcularJuros(decimal decValorInicial, int intMeses)
        {
            decimal decResultado = decValorInicial;
            decimal decTaxaJuros = await GetTaxaJuros();

            for (int i = 0; i < intMeses; i++)
                decResultado = CalcularValorFinal(decResultado, decTaxaJuros);
            
            return Convert.ToDecimal(string.Format("{0:N2}", decResultado));
        }
        
        public async Task<decimal> GetTaxaJuros()
        {
            string strUrl = "https://localhost:44312/taxaJuros";
            var response = await objClient.GetAsync(strUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            decimal decTaxaJuros = JsonConvert.DeserializeObject<decimal>(content);
            return decTaxaJuros;
        }

        private static decimal CalcularValorFinal(decimal decValor, decimal decTaxaJuros)
        {
            decValor *= (1 + decTaxaJuros);
            return decValor;
        }
    }
}
