namespace CopaDeEquipes.Domain
{
    public class Final
    {
        private Partida _partida;

        public Final(Partida partida)
        {
            _partida = partida;
        }

        public void JogarPartida()
        {
            _partida.Jogar();
        }


        public Equipe EquipeCampea()
        {
            return _partida.EquipeVencedora;
        }

        public Equipe EquipeViceCampea()
        {
            return _partida.EquipePerdedora;
        }
    }
}
