using System.Collections.Generic;
using System.Threading.Tasks;
using CopaDeEquipes.Application.Models;
using CopaDeEquipes.Application.Services;
using CopaDeEquipes.Apresentation.Dtos;
using CopaDeEquipes.Apresentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CopaDeEquipes.Apresentation.Controllers
{    
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
        public IActionResult GerarCopa([FromBody] PostGerarCopaDto postDto)
        {
            ResultadoCopaAppModel resultado;                            
            resultado = _copaService.GerarCopa(postDto.Equipes);            
            return Ok(resultado);
        }        
    }
}