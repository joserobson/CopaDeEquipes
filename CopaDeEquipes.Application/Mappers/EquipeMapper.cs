using CopaDeEquipes.Application.Models;
using CopaDeEquipes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaDeEquipes.Application.Mappers
{
    public class EquipeMapper
    {

        static Equipe ToEquipeDomain(EquipeAppModel appModel)
        {
            return new Domain.Equipe(           
                new Guid(appModel.Id),
                appModel.Nome,
                appModel.Sigla,
                appModel.Gols);
        }

        public static IEnumerable<Equipe> ToEquipeDomain(IEnumerable<EquipeAppModel> equipes)
        {
            return equipes.Select(ToEquipeDomain);
        }

    }
}
