using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDeEquipes.Domain
{
    public interface IPartida
    {
        void Jogar();
        Equipe EquipeVencedora { get; }

        Equipe EquipePerdedora { get; }
    }
}
