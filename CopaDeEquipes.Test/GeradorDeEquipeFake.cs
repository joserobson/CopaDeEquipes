using Bogus;
using CopaDeEquipes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaDeEquipes.Test
{
    public class GeradorDeEquipes
    {

        public static Equipe GerarEquipeFake(string nome, long gols)
        {
            var fake = new Faker<Equipe>()
                .RuleFor(e => e.Id, (f, e) => f.Random.Guid())
                .RuleFor(e => e.Nome, (f, e) => nome)
                .RuleFor(e => e.Sigla, (f, e) => GerarSiglaEquipe())
                .RuleFor(e => e.Gols, (f, e) => gols)
                ;

            return fake.Generate();
        }

        public static Equipe GerarEquipeFake(long gols)
        {
            var fake = new Faker<Equipe>()
                .RuleFor(e => e.Id, (f, e) => f.Random.Guid())
                .RuleFor(e => e.Nome, (f, e) => GerarNomeEquipe())
                .RuleFor(e => e.Sigla, (f, e) => GerarSiglaEquipe())
                .RuleFor(e => e.Gols, (f, e) => gols)
                ;

            return fake.Generate();
        }

        public static Equipe GerarEquipeFake()
        {
            var fake =  new Faker<Equipe>()
                .RuleFor(e => e.Id, (f, e) => f.Random.Guid())
                .RuleFor(e => e.Nome, (f, e) => GerarNomeEquipe())
                .RuleFor(e => e.Sigla, (f, e) => GerarSiglaEquipe())
                .RuleFor(e => e.Gols, (f, e) => f.Random.Long(1,10))
                ;

            return fake.Generate();
        }

        public static IEnumerable<Equipe> GerarListaDeEquipes(int tamanho)
        {
            var equipes = new List<Equipe>();

            for (int i = 0; i < tamanho; i++)
            {

                var equipe = GerarEquipeFake();

                if (!equipes.Any(e => e.Nome.Equals(equipe.Nome)))
                    equipes.Add(equipe);
                else
                    i -= 1;
            }

            return equipes;
        }


        private static string GerarNomeEquipe()
        {
            return $"Equipe {new Random().Next(1,20)}";
        }

        private static string GerarSiglaEquipe()
        {
            return $"EPQ{new Random().Next(1, 20)}";
        }
    }
}
