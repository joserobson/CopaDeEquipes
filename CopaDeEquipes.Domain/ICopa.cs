namespace CopaDeEquipes.Domain
{
    public interface ICopa
    {
        bool EhValida();

        void Iniciar();

        Equipe EquipeCampea { get; }
        Equipe EquipeViceCampea { get; }
    }
}
