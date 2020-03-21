using System;
using System.ComponentModel.DataAnnotations;

namespace Applications.Models
{
    public class CalculaJurosRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Valor mínimo de 1")]
        public decimal ValorInicial { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Valor mínimo de 1")]
        public int Meses { get; set; }
    }
}
