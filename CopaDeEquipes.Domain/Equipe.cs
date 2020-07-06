using System;

namespace CopaDeEquipes.Domain
{
    public class Equipe
    {
        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public string Sigla { get; private set; }

        public long Gols { get; set; }

        public Equipe()
        {

        }

        public Equipe(Guid id, string nome, string sigla, long gols)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sigla = sigla;
            this.Gols = gols;
        }

    }
}
