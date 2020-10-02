using ProjetoFilmes.Domains;

namespace ProjetoFilmes.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de usuários
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário autenticado</returns>
        Usuarios Login(string email, string senha);
    }
}
