using System;
using Microsoft.AspNetCore.Mvc;
using ProjetoFilmes.Domains;
using ProjetoFilmes.Interfaces;
using ProjetoFilmes.Repositories;

namespace ProjetoFilmes.Controllers
{
    // Define o tipo de resposta da API
    [Produces("application/json")]

    // Define a rota da aplicação
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FilmesController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto que recebe os métodos estabelecidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository;

        /// <summary>
        /// Instancia este objeto com as implementações feitas no repositório
        /// </summary>
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Retorna uma lista de filmes</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_filmeRepository.Listar());
        }

        /// <summary>
        /// Busca um filme através do ID
        /// </summary>
        /// <param name="id">ID do filme que será buscado</param>
        /// <returns>Retorna um filme buscado</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                Filmes filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado != null)
                {
                    return Ok(filmeBuscado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return NotFound("Nenhum filme foi encontrado.");
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme"></param>
        /// <returns>Retorna um status code</returns>
        [HttpPost]
        public IActionResult Cadastrar(Filmes novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza um filme existente
        /// </summary>
        /// <param name="id">ID do filme que será atualizado</param>
        /// <param name="filmeAtualizado">Objeto com as novas informações</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Filmes filmeAtualizado)
        {
            try
            {
                Filmes filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado != null)
                {
                    _filmeRepository.Atualizar(id, filmeAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Nenhum filme encontrado para o ID informado.");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="id">ID do filme que será deletado</param>
        /// <returns>Retorna um status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Filmes filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado != null)
                {
                    _filmeRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum filme encontrado para o ID informado.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}