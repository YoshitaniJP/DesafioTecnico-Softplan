using System.Threading.Tasks;
using Applications.Interfaces;
using Applications.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [Route("calculajuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService objICalcularJurosService;
        
        public CalculaJurosController(ICalculaJurosService _objICalcularJurosService)
        {
            objICalcularJurosService = _objICalcularJurosService;
        }

        [HttpGet]
        public async Task<IActionResult> CalcularJuros([FromQuery] CalculaJurosRequest objRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var resultado = await objICalcularJurosService.CalcularJuros(objRequest.ValorInicial, objRequest.Meses);
            return Ok(resultado);
        }
    }
}
