using ProjetoFilmes.Domains;
using ProjetoFilmes.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFilmes.Repositories
{
    /// <summary>
    /// Repositório que implementa os métodos de gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// Instancia um novo contexto para utilizar os métodos do EF Core
        /// </summary>
        FilmesContext ctx = new FilmesContext();

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="idAtualizar">ID do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int idAtualizar, Generos generoAtualizado)
        {
            Generos generoAtual = BuscarPorId(idAtualizar);

            if (generoAtual != null)
            {
                generoAtual.Nome = generoAtualizado.Nome;
            }

            ctx.Generos.Update(generoAtual);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um gênero através do seu ID
        /// </summary>
        /// <param name="idBuscar">ID do gênero que será buscado</param>
        /// <returns>Retorna um gênero buscado</returns>
        public Generos BuscarPorId(int idBuscar)
        {
            Generos generoBuscado = ctx.Generos.Find(idBuscar);

            return generoBuscado;
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(Generos novoGenero)
        {
            ctx.Generos.Add(novoGenero);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="idDeletar">ID do gênero que será deletado</param>
        public void Deletar(int idDeletar)
        {
            ctx.Generos.Remove(BuscarPorId(idDeletar));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        public List<Generos> Listar()
        {
            return ctx.Generos.ToList();
        }
    }
}
