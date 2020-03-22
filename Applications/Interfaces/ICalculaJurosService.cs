﻿using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICalculaJurosService
    {
        Task<decimal> CalcularJuros(decimal decValorInicial, int intMeses);
        Task<decimal> GetTaxaJuros();
    }
}
