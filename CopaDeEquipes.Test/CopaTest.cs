using CopaDeEquipes.Domain;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace CopaDeEquipes.Test
{
    public class CopaTest
    {
        [Fact]
        public void Copa_Jogar_AcertarCampeao()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(8);
            var copa = new Copa(equipes);

            if (copa.EhValida())
            {
                copa.Iniciar();

                var equipeComMaisGols = equipes.OrderBy(e => e.Gols).ToArray();
                var equipeCampea = equipeComMaisGols[equipeComMaisGols.Count() - 1];                

                Assert.True(copa.EquipeCampea.Equals(equipeCampea));
            }
        }


        [Fact]
        public void Copa_EhValida_PossuiOitoEquipes()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(8);
            var copa = new Copa(equipes);

            Assert.True(copa.EhValida());
        }

        [Fact]
        public void Copa_EhValida_ListaVazia()
        {
            var equipes = new List<Equipe>();
            var copa = new Copa(equipes);

            Assert.Throws<ArgumentException>(()=>copa.EhValida());
        }

        [Fact]
        public void Copa_EhValida_PossuiMenosDeOitoEquipes()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(5);
            var copa = new Copa(equipes);

            Assert.Throws<ArgumentException>(() => copa.EhValida());
        }

        [Fact]
        public void Copa_EhValida_PossuiMaisDeOitoEquipes()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(15);
            var copa = new Copa(equipes);

            Assert.Throws<ArgumentException>(() => copa.EhValida());
        }

        [Fact]
        public void Copa_EhValida_PossuiDuasEquipesComMesmoNome()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(7).ToList();
            equipes.Add(equipes[0]);

            var copa = new Copa(equipes);

            Assert.Throws<ArgumentException>(() => copa.EhValida());
        }


        [Fact]
        public void Copa_EhValida_NaoPossuiEquipesComNomesRepetidos()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(8);
            var copa = new Copa(equipes);

            Assert.True(copa.EhValida());
        }
    }
}
