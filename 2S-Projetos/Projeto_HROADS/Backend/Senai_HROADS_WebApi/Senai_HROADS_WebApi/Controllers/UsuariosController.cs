using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_HROADS_WebApi.Domains;
using Senai_HROADS_WebApi.Interfaces;
using Senai_HROADS_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    // Controller responsável pelos endpoints (URLs) referentes aos Usuario
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
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarId(IdUsuario);
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
    }
}
