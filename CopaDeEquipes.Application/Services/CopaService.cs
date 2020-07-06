using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CopaDeEquipes.Application.Mappers;
using CopaDeEquipes.Application.Models;
using CopaDeEquipes.Domain;
using Newtonsoft.Json;

namespace CopaDeEquipes.Application.Services
{
    public class CopaService : ICopaService
    {
        public ResultadoCopaAppModel GerarCopa(IEnumerable<EquipeAppModel> equipesSelecionadas)
        {
            var resultadoCopa = new ResultadoCopaAppModel();

            var equipes = EquipeMapper.ToEquipeDomain(equipesSelecionadas);
            var copa = new Copa(equipes);

            if (copa.EhValida())
            {
                copa.Iniciar();

                resultadoCopa.Campeao = copa.EquipeCampea.Nome;
                resultadoCopa.ViceCampeao = copa.EquipeViceCampea.Nome;
            }

            return resultadoCopa;
        }

        public async Task<IEnumerable<EquipeAppModel>> ObterEquipes()
        {
            const string URL_JSON_EQUIPES = "https://raw.githubusercontent.com/delsonvictor/testetecnico/master/equipes.json";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                var resposta = await client.GetAsync(URL_JSON_EQUIPES);

                if (resposta.IsSuccessStatusCode)
                {
                    var json = await resposta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<EquipeAppModel>>(json);                                  
                }
            }

            return new List<EquipeAppModel>();
        }
    }
}
