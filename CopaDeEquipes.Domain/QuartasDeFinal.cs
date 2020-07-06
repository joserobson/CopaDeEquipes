using System.Collections.Generic;
using System.Linq;

namespace CopaDeEquipes.Domain
{
    internal sealed class QuartasDeFinal
    {
        private const int NUMERO_PARTIDAS = 4;
        private IDictionary<int,Partida> _partidas = new Dictionary<int,Partida>(NUMERO_PARTIDAS);        

        public QuartasDeFinal()
        {            
        }

        public void SortearPartidas(IEnumerable<Equipe> equipes)
        {
            var equipesOrdenadas = equipes.OrderBy(x => x.Nome).ToList();

            for (int i = 0; i < NUMERO_PARTIDAS; i++)
            {
                var posicaoInicial = i;
                var posicaFinal = (equipesOrdenadas.Count - 1) - i;

                var partida = new Partida(equipesOrdenadas[posicaoInicial], equipesOrdenadas[posicaFinal]);
                _partidas.Add(i, partida);
            }
        }

        public void JogarPartidas()
        {
            foreach (var partida in this._partidas.Values)
            {
                partida.Jogar();                
            }
        }

        public SemiFinais ObterSemiFinais()
        {
            var partidasDaSemiFinal = new List<Partida>(2);            

            var primeiraSemifinal = new Partida(_partidas[0].EquipeVencedora, _partidas[1].EquipeVencedora);
            partidasDaSemiFinal.Add(primeiraSemifinal);

            var segundaSemifinal = new Partida(_partidas[2].EquipeVencedora, _partidas[3].EquipeVencedora);
            partidasDaSemiFinal.Add(segundaSemifinal);

            return new SemiFinais(partidasDaSemiFinal);
        }


    }
}
