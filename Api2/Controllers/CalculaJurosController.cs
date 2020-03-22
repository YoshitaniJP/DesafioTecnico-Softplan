using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [Route("calculajuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService iCalcularJurosService;
        
        public CalculaJurosController(ICalculaJurosService _iCalcularJurosService)
        {
            iCalcularJurosService = _iCalcularJurosService;
        }

        [HttpGet]
        public async Task<IActionResult> CalcularJuros([FromQuery] CalculaJurosRequest objRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            decimal resultado = await iCalcularJurosService.CalcularJuros(objRequest.ValorInicial, objRequest.Meses);
            return Ok(resultado);
        }
    }
}
