using System.Threading.Tasks;
using Api2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [Route("calculajuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly CalculaJurosService objCalcularJurosService;
        
        public CalculaJurosController(CalculaJurosService _objCalcularJurosService)
        {
            objCalcularJurosService = _objCalcularJurosService;
        }

        [HttpGet]
        public async Task<IActionResult> CalcularJuros(decimal ValorInicial, int Meses)
        {
            var resultado = await objCalcularJurosService.CalcularJuros(ValorInicial, Meses);
            return Ok(resultado);
        }
    }
}
