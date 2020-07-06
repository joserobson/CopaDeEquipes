using System.Collections.Generic;
using System.Linq;

namespace CopaDeEquipes.Domain
{
    public class Partida
    {
        private readonly Equipe _equipeA;
        private readonly Equipe _equipeB;

        public Equipe EquipeVencedora { get; private set; }

        public Equipe EquipePerdedora { get; private set; }

        public Partida(Equipe equipeA, Equipe equipeB)
        {
            this._equipeA = equipeA;
            this._equipeB = equipeB;
        }

        public void Jogar()
        {
            if (this._equipeA.Gols > this._equipeB.Gols)
            {
                EquipeVencedora = this._equipeA;
                EquipePerdedora = this._equipeB;
            }
            else
            {
                if (this._equipeB.Gols > this._equipeA.Gols)
                {
                    EquipeVencedora = this._equipeB;
                    EquipePerdedora = this._equipeA;
                }
                else
                {
                    if (this._equipeA.Gols == this._equipeB.Gols)
                        this.Desempatar(); 
                }
            }
        }

        private void Desempatar()
        {
            var equipes = new List<Equipe>
            {
                _equipeA,
                _equipeB
            };

            var equipesOrdenadas = equipes
                .OrderBy(x => new string(x.Nome.Where(char.IsLetter).ToArray()))
                .ThenBy(x =>
                {
                    int number;
                    if (int.TryParse(new string(x.Nome.Where(char.IsDigit).ToArray()), out number))
                        return number;
                    return -1;
                }).ToList();
            
            EquipeVencedora = equipesOrdenadas.First();
            EquipePerdedora = equipesOrdenadas.Last();
        }
    }
}
