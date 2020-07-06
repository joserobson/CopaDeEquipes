using CopaDeEquipes.Domain;
using Xunit;

namespace CopaDeEquipes.Test
{
    public class PartidaTest
    {

        [Fact]
        public void Partida_Jogar_EquipeAVencedora()
        {
            var equipeA = GeradorDeEquipes.GerarEquipeFake(2);            
            var equipeB = GeradorDeEquipes.GerarEquipeFake(1);

            var partida = new Partida(equipeA, equipeB);
            partida.Jogar();

            Assert.True(partida.EquipeVencedora.Equals(equipeA));
        }

        [Fact]
        public void Partida_Jogar_EquipeBVencedora()
        {
            var equipeA = GeradorDeEquipes.GerarEquipeFake(2);
            var equipeB = GeradorDeEquipes.GerarEquipeFake(4);

            var partida = new Partida(equipeA, equipeB);
            partida.Jogar();

            Assert.True(partida.EquipeVencedora.Equals(equipeB));
        }

        [Fact]
        public void Partida_Jogar_EmpateEquipeAGanharPorOrdemAlfabetica_PrimeiroCenario()
        {
            var equipeA = GeradorDeEquipes.GerarEquipeFake("Equipe 1",2);
            var equipeB = GeradorDeEquipes.GerarEquipeFake("Equipe 8",2);

            var partida = new Partida(equipeA, equipeB);
            partida.Jogar();

            Assert.True(partida.EquipeVencedora.Equals(equipeA));
        }

        [Fact]
        public void Partida_Jogar_EmpateEquipeAGanharPorOrdemAlfabetica_SegundoCenario()
        {
            var equipeA = GeradorDeEquipes.GerarEquipeFake("Equipe 19", 2);
            var equipeB = GeradorDeEquipes.GerarEquipeFake("Equipe 100", 2);

            var partida = new Partida(equipeA, equipeB);
            partida.Jogar();

            Assert.True(partida.EquipeVencedora.Equals(equipeA));
        }

        [Fact]
        public void Partida_Jogar_EmpateEquipeAGanharPorOrdemAlfabetica_TerceiroCenario()
        {
            var equipeA = GeradorDeEquipes.GerarEquipeFake("Equipe", 2);
            var equipeB = GeradorDeEquipes.GerarEquipeFake("Equipe 1", 2);

            var partida = new Partida(equipeA, equipeB);
            partida.Jogar();

            Assert.True(partida.EquipeVencedora.Equals(equipeA));
        }        
    }
}
