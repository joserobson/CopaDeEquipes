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
        public void Copa_EhValida_PossuiOitoEquipes()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(8);
            var copa = Copa.Factory.NovaCopa(equipes);

            Assert.True(copa.AtendeTodosOsCriterios());
        }

        [Fact]
        public void Copa_EhValida_ListaVazia()
        {
            var equipes = new List<Equipe>();
            var copa = Copa.Factory.NovaCopa(equipes);

            Assert.Throws<ArgumentException>(()=>copa.AtendeTodosOsCriterios());
        }

        [Fact]
        public void Copa_EhValida_PossuiMenosDeOitoEquipes()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(5);
            var copa = Copa.Factory.NovaCopa(equipes);

            Assert.Throws<ArgumentException>(() => copa.AtendeTodosOsCriterios());
        }

        [Fact]
        public void Copa_EhValida_PossuiMaisDeOitoEquipes()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(15);
            var copa = Copa.Factory.NovaCopa(equipes);

            Assert.Throws<ArgumentException>(() => copa.AtendeTodosOsCriterios());
        }

        [Fact]
        public void Copa_EhValida_PossuiDuasEquipesComMesmoNome()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(7).ToList();
            equipes.Add(equipes[0]);

            var copa = Copa.Factory.NovaCopa(equipes);

            Assert.Throws<ArgumentException>(() => copa.AtendeTodosOsCriterios());
        }


        [Fact]
        public void Copa_EhValida_NaoPossuiEquipesComNomesRepetidos()
        {
            var equipes = GeradorDeEquipes.GerarListaDeEquipes(8);
            var copa = Copa.Factory.NovaCopa(equipes);

            Assert.True(copa.AtendeTodosOsCriterios());
        }
    }
}
