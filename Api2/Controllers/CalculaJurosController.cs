using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper objMapper;

        public CalculaJurosController(ICalculaJurosService _iCalcularJurosService, IMapper _objMapper)
        {
            iCalcularJurosService = _iCalcularJurosService;
            objMapper = _objMapper;
        }

        [HttpGet]
        public async Task<IActionResult> CalcularJuros([FromQuery] CalculaJurosRequest objRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            decimal resultado = await iCalcularJurosService.CalcularJuros(objMapper.Map<CalculaJuros>(objRequest));
            return Ok(resultado);
        }
    }
}
