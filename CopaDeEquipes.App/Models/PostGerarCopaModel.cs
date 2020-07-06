using CopaDeEquipes.Application.Models;
using System.Collections.Generic;

namespace CopaDeEquipes.App.Models
{
    public class PostGerarCopaModel
    {
        public List<EquipeAppModel> Equipes { get; set; }

        public string Equipe { get; set; }
    }
}
