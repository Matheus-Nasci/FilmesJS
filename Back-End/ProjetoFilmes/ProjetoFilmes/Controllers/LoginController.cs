using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjetoFilmes.Domains;
using ProjetoFilmes.Interfaces;
using ProjetoFilmes.Repositories;
using ProjetoFilmes.ViewModels;

namespace ProjetoFilmes.Controllers
{
    // Define o tipo de resposta da API
    [Produces("application/json")]

    // Define a rota da aplicação
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto que recebe os métodos estabelecidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Instancia este objeto com as implementações feitas no repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto com as informações de login</param>
        /// <returns>Retorna um usuário autenticado</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                // Busca um usuário através do e-mail e senha
                Usuarios usuarioAutenticado = _usuarioRepository.Login(login.Email, login.Senha);

                // Caso não seja encontrado, retorna o status code 404 com a mensagem de erro
                if (usuarioAutenticado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }

                // Define as claims do token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioAutenticado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioAutenticado.IdUsuario.ToString()),

                    new Claim(ClaimTypes.Role, usuarioAutenticado.Permissao)
                };

                // Define a chave de autenticação
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

                // Define as credenciais do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Define as informações do token
                var token = new JwtSecurityToken(
                    // Define o emissor
                    issuer: "Filmes.WebApi",
                    // Define o receptor
                    audience: "Filmes.WebApi",
                    // Define as claims
                    claims: claims,
                    // Define o tempo de expiração
                    expires: DateTime.Now.AddMinutes(30),
                    // Define as credenciais de assinatura
                    signingCredentials: creds
                );

                // Retorna o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }

            // Caso ocorra algum erro, retorna o status code 400 com a mensagem e o código do erro
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não foi possível gerar o token",
                    error
                });
            }
        }
    }
}