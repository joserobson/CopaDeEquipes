using CopaDeEquipes.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeEquipes.Application.Services
{
    public interface ICopaService
    {
        Task<IEnumerable<EquipeAppModel>> ObterEquipes();

        ResultadoCopaAppModel GerarCopa(IEnumerable<EquipeAppModel> equipesSelecionadas);
    }
}
