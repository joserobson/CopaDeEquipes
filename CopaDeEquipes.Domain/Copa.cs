using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaDeEquipes.Domain
{
    public sealed class Copa: ICopa
    {
        private const long NUM_MAXIMO_EQUIPES_PARTICIPANTES = 8;

        public Equipe EquipeCampea { get; private set; }
        public Equipe EquipeViceCampea { get; private set; }

        private readonly IEnumerable<Equipe> _equipesParticipantes;
        private QuartasDeFinal _quartasDeFinal;
        private SemiFinais _semiFinais;
        private Final _final;

        private Copa(IEnumerable<Equipe> equipesParticipantes)
        {
            this._equipesParticipantes = equipesParticipantes;            
        }

        public bool AtendeTodosOsCriterios()
        {
            if (this._equipesParticipantes == null ||
                this._equipesParticipantes.Count() < NUM_MAXIMO_EQUIPES_PARTICIPANTES ||
                this._equipesParticipantes.Count() > NUM_MAXIMO_EQUIPES_PARTICIPANTES)
            {
                throw new ArgumentException("Copa Inválida, são necessárias oito equipes para iniciar a copa.");
            }

            var contadorPorNomes = this._equipesParticipantes.Select(e => e.Nome).Distinct().Count();
            if (contadorPorNomes < this._equipesParticipantes.Count())
            {
                throw new ArgumentException("Copa Inválida, existem equipes com nomes repetidos.");
            }

            return true;
        }

        public void Iniciar()
        {
            _quartasDeFinal = new QuartasDeFinal();

            _quartasDeFinal.SortearPartidas(this._equipesParticipantes);

            _quartasDeFinal.JogarPartidas();

            _semiFinais = _quartasDeFinal.ObterSemiFinais();

            _semiFinais.JogarPartidas();

            _final = _semiFinais.ObterFinal();

            _final.JogarPartida();

            this.EquipeCampea = _final.EquipeCampea();
            this.EquipeViceCampea = _final.EquipeViceCampea();
        }

        public static class Factory
        {
            public static ICopa NovaCopa(IEnumerable<Equipe> equipesParticipantes)
            {
                return new Copa(equipesParticipantes);
            }
        }

    }
}
