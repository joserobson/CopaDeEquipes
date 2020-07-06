
using System.Collections.Generic;
using System.Linq;

namespace CopaDeEquipes.Domain
{
    internal class SemiFinais
    {
        private IEnumerable <Partida> _partidas = new List<Partida>(2);        

        public SemiFinais(IEnumerable<Partida> partidas)
        {
            _partidas = partidas;
        }

        public void JogarPartidas()
        {
            foreach (var partida in this._partidas)
            {
                partida.Jogar();
            }
        }

        public Final ObterFinal()
        {
            var partidaFinal = new Partida(
                _partidas.First().EquipeVencedora,
                _partidas.Last().EquipeVencedora);               

            return new Final(partidaFinal);
        }
    }
}
