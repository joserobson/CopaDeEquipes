namespace CopaDeEquipes.Domain
{
    public interface ICopa
    {
        bool AtendeTodosOsCriterios();

        void Iniciar();

        Equipe EquipeCampea { get; }
        Equipe EquipeViceCampea { get; }
    }
}
