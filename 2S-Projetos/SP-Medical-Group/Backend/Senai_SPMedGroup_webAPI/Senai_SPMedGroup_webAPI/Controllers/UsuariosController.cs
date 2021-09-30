using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using Senai_SPMedGroup_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    // Controller responsável pelos endpoints (URLs) referentes aos Usuario
    //   IdTipoUsuario
    // 1 - Administrador
    // 2 - Médico
    // 3 - Paciente
    public class UsuariosController : ControllerBase
    {      
            /// <summary>
            /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
            /// </summary>
            private IUsuarioRepository _usuarioRepository { get; set; }

            /// <summary>
            /// Instancia o objeto _usuarioRepository para que haja referência às implementações feitas no repositório UsuarioRepository
            /// </summary>
            public UsuariosController()
            {
                _usuarioRepository = new UsuarioRepository();
            }
            /// <summary>
            /// Lista todos os usuários
            /// </summary>
            /// <returns>Uma lista de usuários com o status code 200 - Ok</returns>
            /// 
            [Authorize(Roles = "1")]
            [HttpGet]
            public IActionResult Listar()
            {
                try
                {
                    List<Usuario> listaUsuario = _usuarioRepository.ListarTodos();
                    return Ok(listaUsuario);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            /// <summary>
            /// Busca um usuario através do seu id
            /// </summary>
            /// <param name="IdUsuario">ID do usuario que será buscado</param>
            /// <returns>Um usuário encontrado com o status code 200 - Ok</returns>
            /// 
            [Authorize(Roles = "1")]
            [HttpGet("{IdUsuario}")]
            public IActionResult BuscarPorId(int IdUsuario)
            {

            Usuario usuarioBuscado = _usuarioRepository.BuscarId(IdUsuario);
            if (usuarioBuscado == null) 
            {
                return NotFound
                        (new
                        {
                            mensagem = "Usuários não encontrado!",
                            erro = true
                        });
            }
            try
                {                 
                    // Retorna um Usuario encontrado
                    return Ok(usuarioBuscado);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            
        }

            /// <summary>
            /// Cadastra um Usuário
            /// </summary>
            /// <param name="novoUsuario">Objeto novoUsuario com as informações</param>
            /// <returns>Um status code 201 - Created</returns>
            [Authorize(Roles = "1")]
            [HttpPost]
            public IActionResult Cadastrar(Usuario novoUsuario)
            {       
                try
                {
                    // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
                    _usuarioRepository.Cadastrar(novoUsuario);
                    // Retorna um status code 201
                    return StatusCode(201);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            /// <summary>
            /// Atualiza um Usuário existente
            /// </summary>
            /// <param name="IdUsuario">ID do Usuario que será atualizado</param>
            /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
            /// <returns>Um status code 204 - No Content</returns>
            /// 
            [Authorize(Roles = "1")]
            [HttpPut("{IdUsuario}")]
            public IActionResult Atualizar(int IdUsuario, Usuario usuarioAtualizado)
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarId(IdUsuario);
                if (usuarioBuscado == null)
                {
                    return NotFound
                        (new
                        {
                            mensagem = "Usuários não encontrado!",
                            erro = true
                        });
                }
                try
                {
                    // Faz a chamada para o método .Atualizar enviando as novas informações
                    _usuarioRepository.Atualizar(IdUsuario, usuarioAtualizado);
                    // Retorna um status code 204
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            /// <summary>
            /// Deleta um Usuário existente
            /// </summary>
            /// <param name="IdUsuario">ID do usuário que será deletado</param>
            /// <returns>Um status code 204 - No Content</returns>
            /// 
            [Authorize(Roles = "1")]
            [HttpDelete("{IdUsuario}")]
            public IActionResult Deletar(int IdUsuario)
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarId(IdUsuario);
                if (usuarioBuscado != null)
                {
                    try
                    {
                        _usuarioRepository.Deletar(IdUsuario);
                        return StatusCode(204);
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro);
                    }
                }
                return NotFound("Nenhum Usuário foi encontrado!");
            }


        /// <summary>
        /// Envia uma imagem para o banco de dados
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        [Authorize(Roles = "1,2")]
        [HttpPost("imagem/bd")]
        public IActionResult postBD(IFormFile arquivo)
        {
            try
            {
                //analisar o tamanho do arquivo
                if (arquivo.Length > 5000000) //5MB
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                //analise da extensao do arquivo
                //Split = retorna uma matriz de caracteres
                //Last = recupera a ultima posição da matriz.
                string extensao = arquivo.FileName.Split('.').Last();


                if (extensao != "png")
                    return BadRequest(new { mensagem = "Apenas arquivos .png são obrigatórios." });

                //recuperar id do usuario logado a partir do token.
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarPerfilBD(arquivo, idUsuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Puxa a imagem do banco de dados
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1,2")]
        [HttpGet("imagem/bd")]
        public IActionResult getBD()
        {
            try
            {

                //recuperar id do usuario logado a partir do token.
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _usuarioRepository.ConsultarPerfilBD(idUsuario);

                return Ok(base64);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// envia a imagem para o diretório
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        [Authorize(Roles = "1,2")]
        [HttpPost("imagem/dir")]
        public IActionResult postDir(IFormFile arquivo)
        {
            try
            {
                //analisar o tamanho do arquivo
                if (arquivo.Length > 5000000) //5MB
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                //analise da extensao do arquivo
                //Split = retorna uma matriz de caracteres
                //Last = recupera a ultima posição da matriz.
                string extensao = arquivo.FileName.Split('.').Last();


                if (extensao != "png")
                    return BadRequest(new { mensagem = "Apenas arquivos .png são obrigatórios." });

                //recuperar id do usuario logado a partir do token.
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarPerfilDir(arquivo, idUsuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Puxa a imagem do diretório
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1,2")]
        [HttpGet("imagem/dir")]
        public IActionResult getDIR()
        {
            try
            {

                //recuperar id do usuario logado a partir do token.
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _usuarioRepository.ConsultarPerfilDir(idUsuario);

                return Ok(base64);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
