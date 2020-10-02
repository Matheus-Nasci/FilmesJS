using ProjetoFilmes.Domains;
using ProjetoFilmes.Interfaces;
using System.Linq;

namespace ProjetoFilmes.Repositories
{
    /// <summary>
    /// Repositório que implementa os métodos de usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Instancia um novo contexto para utilizar os métodos do EF Core
        /// </summary>
        FilmesContext ctx = new FilmesContext();

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário autenticado</returns>
        public Usuarios Login(string email, string senha)
        {
            // Busca um usuário através do e-mail e senha informados
            Usuarios usuarioAutenticado = ctx.Usuarios
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            // Caso seja encontrado, retorna todos os dados deste usuário
            if (usuarioAutenticado != null)
            {
                return usuarioAutenticado;
            }

            // Caso não, retorna nulo
            return null;
        }
    }
}
