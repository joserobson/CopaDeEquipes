using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaDeEquipes.Domain
{
    public class Copa
    {
        private const long NUM_MAXIMO_EQUIPES_PARTICIPANTES = 8;

        public Equipe EquipeCampea { get; private set; }
        public Equipe EquipeViceCampea { get; private set; }

        private IEnumerable<Equipe> _equipesParticipantes;               
        public QuartasDeFinal QuartasDeFinal { get; private set; }
        public SemiFinais SemiFinais { get; private set; }
        public Final Final { get; private set; }

        public Copa(IEnumerable<Equipe> equipesParticipantes)
        {
            this._equipesParticipantes = equipesParticipantes;
            QuartasDeFinal = new QuartasDeFinal();
        }


        public bool EhValida()
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
            QuartasDeFinal.SortearPartidas(this._equipesParticipantes);

            QuartasDeFinal.JogarPartidas();

            SemiFinais = QuartasDeFinal.ObterSemiFinais();

            SemiFinais.JogarPartidas();

            Final = SemiFinais.ObterFinal();

            Final.JogarPartida();

            this.EquipeCampea = Final.EquipeCampea();
            this.EquipeViceCampea = Final.EquipeViceCampea();
        }
                                
    }
}
