using CopaDeEquipes.Application.Models;
using System.Collections.Generic;

namespace CopaDeEquipes.Apresentation.Dtos
{
    public class PostGerarCopaDto
    {
        public List<EquipeAppModel> Equipes { get; set; }

        public string Equipe { get; set; }
    }
}
