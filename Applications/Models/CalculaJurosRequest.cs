using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class CalculaJurosRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Valor inválido: o mínimo é 1")]
        public decimal ValorInicial { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Valor inválido: o mínimo é 1")]
        public int Meses { get; set; }
    }
}
