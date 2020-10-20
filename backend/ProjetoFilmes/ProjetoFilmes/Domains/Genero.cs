using System;
using System.Collections.Generic;

namespace ProjetoFilmes.Domains
{
    public partial class Genero
    {
        public Genero()
        {
            Filmes = new HashSet<Filme>();
        }

        public int IdGenero { get; set; }
        public string Nome { get; set; }

        public ICollection<Filme> Filmes { get; set; }
    }
}
