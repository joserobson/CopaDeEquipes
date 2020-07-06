using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CopaDeEquipes.App.Filters;
using CopaDeEquipes.App.Models;
using CopaDeEquipes.Application.Models;
using CopaDeEquipes.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CopaDeEquipes.App.Controllers
{
    //[Produces("application/json")]
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    public class CopaController : Controller
    {
        private readonly ICopaService _copaService;

        public CopaController(ICopaService copaService)
        {
            _copaService = copaService;
        }

        [HttpGet("[action]")]
        public Task<IEnumerable<EquipeAppModel>> ObterEquipes()
        {                        
            return _copaService.ObterEquipes();            
        }

        [HttpPost("[action]")]
        public IActionResult GerarCopa([FromBody] PostGerarCopaModel postModel)
        {
            ResultadoCopaAppModel resultado;
            try
            {                
                resultado = _copaService.GerarCopa(postModel.Equipes);

            }catch(Exception error)
            {
                throw error;
            }

            return Ok(resultado);
        }        
    }
}