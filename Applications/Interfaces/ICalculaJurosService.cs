using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Interfaces
{
    public interface ICalculaJurosService
    {
        Task<decimal> CalcularJuros(decimal decValorInicial, int intMeses);
        Task<decimal> GetTaxaJuros();
    }
}
