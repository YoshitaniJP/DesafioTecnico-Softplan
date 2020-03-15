using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [Route("showmethecode")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetShowMeTheCode()
        {
            string strUrl = "https://github.com/YoshitaniJP/DesafioTecnico-Softplan";
            return Ok(strUrl);
        }
    }
}