using Newtonsoft.Json;

namespace ProjetoFilmes.Domains
{
    public partial class Filme
    {
        public int IdFilme { get; set; }
        public string Titulo { get; set; }
        public int? IdGenero { get; set; }

        [JsonProperty("genero")]
        public Genero IdGeneroNavigation { get; set; }
    }
}
