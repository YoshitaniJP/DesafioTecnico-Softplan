using Domain.Interfaces;
using Infra;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;

namespace Domain.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private HttpClient objClient;
        private readonly IOptions<AppSettings> objConfig;
        private readonly AsyncRetryPolicy<decimal> retry;

        public CalculaJurosService(HttpClient _objClient, IOptions<AppSettings> _objConfig)
        {
            objClient = _objClient;
            objClient.DefaultRequestHeaders.Accept.Clear();
            objClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            objConfig = _objConfig;

            retry = Policy<decimal>.Handle<HttpRequestException>().RetryAsync(5);
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
            return await retry.ExecuteAsync(async () =>
            {
                var response = await objClient.GetAsync(objConfig.Value.Url_ApiTaxaJuros);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                decimal decTaxaJuros = JsonConvert.DeserializeObject<decimal>(content);
                return decTaxaJuros;
            });
        }

        private static decimal CalcularValorFinal(decimal decValor, decimal decTaxaJuros)
        {
            decValor *= (1 + decTaxaJuros);
            return decValor;
        }
    }
}
