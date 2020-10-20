using ProjetoFilmes.Domains;
using System.Collections.Generic;

namespace ProjetoFilmes.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de usuários
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Retorna uma lista de usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuario através do seu ID
        /// </summary>
        /// <param name="idBuscar">ID do usuario que será buscado</param>
        /// <returns>Retorna um usuario buscado</returns>
        Usuario BuscarPorId(int idBuscar);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="idAtualizar">ID do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int idAtualizar, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="idDeletar">ID do usuario que será deletado</param>
        void Deletar(int idDeletar);

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário autenticado</returns>
        Usuario Login(string email, string senha);
    }
}
