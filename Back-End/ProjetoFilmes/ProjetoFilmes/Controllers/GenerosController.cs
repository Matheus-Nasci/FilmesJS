using System;
using Microsoft.AspNetCore.Authorization;
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
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto que recebe os métodos estabelecidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository;

        /// <summary>
        /// Instancia este objeto com as implementações feitas no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_generoRepository.Listar());
        }

        /// <summary>
        /// Busca um gênero através do ID
        /// </summary>
        /// <param name="id">ID do gênero que será buscado</param>
        /// <returns>Retorna um gênero buscado</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                Generos generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado != null)
                {
                    return Ok(generoBuscado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return NotFound("Nenhum gênero foi encontrado.");
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        /// <returns>Retorna um status code</returns>
        [HttpPost]
        public IActionResult Cadastrar(Generos novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="id">ID do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto com as novas informações</param>
        /// <returns>Retorna um status code</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Generos generoAtualizado)
        {
            try
            {
                Generos generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado != null)
                {
                    _generoRepository.Atualizar(id, generoAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Nenhum gênero encontrado para o ID informado.");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">ID do gênero que será deletado</param>
        /// <returns>Retorna um status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Generos generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado != null)
                {
                    _generoRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum gênero encontrado para o ID informado.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}