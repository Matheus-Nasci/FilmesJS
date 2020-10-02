using ProjetoFilmes.Domains;
using System.Collections.Generic;

namespace ProjetoFilmes.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de gêneros
    /// </summary>
    interface IGeneroRepository
    {
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        List<Generos> Listar();

        /// <summary>
        /// Busca um gênero através do seu ID
        /// </summary>
        /// <param name="idBuscar">ID do gênero que será buscado</param>
        /// <returns>Retorna um gênero buscado</returns>
        Generos BuscarPorId(int idBuscar);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(Generos novoGenero);

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="idAtualizar">ID do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int idAtualizar, Generos generoAtualizado);

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="idDeletar">ID do gênero que será deletado</param>
        void Deletar(int idDeletar);
    }
}
