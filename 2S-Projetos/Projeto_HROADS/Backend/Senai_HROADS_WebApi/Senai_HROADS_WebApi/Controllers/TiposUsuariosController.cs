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
    public class TiposUsuariosController : ControllerBase
    {

        // Controller responsável pelos endpoints (URLs) referentes aos TiposUsuarios

        /// <summary>
        /// Objeto _tipoUsuarioRepository que irá receber todos os métodos definidos na interface ITiposUsuarioRepository
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tipoUsuarioRepository para que haja referência às implementações feitas no repositório TipoUsuarioRepository
        /// </summary>
        public TiposUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tiposUsuarios
        /// </summary>
        /// <returns>Uma lista de tiposUsuarios com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<TipoUsuario> listaTipoUsuario = _tipoUsuarioRepository.ListarTodos();
                return Ok(listaTipoUsuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um tipoUsuario através do seu id
        /// </summary>
        /// <param name="IdTipoUsuario">ID do tipoUsuario que será buscado</param>
        /// <returns>Um tipoUsuario encontrado com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{IdTipoUsuario}")]
        public IActionResult BuscarPorId(int IdTipoUsuario)
        {       
            try
            {
                TipoUsuario tiposUsuarioBuscado = _tipoUsuarioRepository.BuscarId(IdTipoUsuario);
                // Retorna um tipo Usuario encontrado
                return Ok(tiposUsuarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um Tipo Usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipoUsuario)
        {
            try
            {
                // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
                // Retorna um status code 201
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um TipoUsuario existente
        /// </summary>
        /// <param name="IdTipoUsuario">ID do tipoUsuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{IdTipoUsuario}")]
        public IActionResult Atualizar(int IdTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarId(IdTipoUsuario);
            if (tipoUsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "tipos de Usuários não encontrado!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _tipoUsuarioRepository.Atualizar(IdTipoUsuario, tipoUsuarioAtualizado);
                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um tipoUsuario existente
        /// </summary>
        /// <param name="IdTipoUsuario">ID do tipoUsuario que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{IdTipoUsuario}")]
        public IActionResult Deletar(int IdTipoUsuario)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarId(IdTipoUsuario);
            if (tipoUsuarioBuscado != null)
            {
                try
                {
                    _tipoUsuarioRepository.Deletar(IdTipoUsuario);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhum Tipo Usuário foi encontrado!");
        }
    }
}
