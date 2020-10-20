using ProjetoFilmes.Domains;
using ProjetoFilmes.Interfaces;
using System.Collections.Generic;
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
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="idAtualizar">ID do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int idAtualizar, Usuario usuarioAtualizado)
        {
            Usuario usuarioAtual = BuscarPorId(idAtualizar);

            if (usuarioAtual != null)
            {
                usuarioAtual = usuarioAtualizado;
            }

            ctx.Usuarios.Update(usuarioAtual);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um usuario através do seu ID
        /// </summary>
        /// <param name="idBuscar">ID do usuario que será buscado</param>
        /// <returns>Retorna um usuario buscado</returns>
        public Usuario BuscarPorId(int idBuscar)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(idBuscar);

            return usuarioBuscado;
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="idDeletar">ID do usuario que será deletado</param>
        public void Deletar(int idDeletar)
        {
            ctx.Usuarios.Remove(BuscarPorId(idDeletar));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Retorna uma lista de usuarios</returns>
        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário autenticado</returns>
        public Usuario Login(string email, string senha)
        {
            // Busca um usuário através do e-mail e senha informados
            Usuario usuarioAutenticado = ctx.Usuarios
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
