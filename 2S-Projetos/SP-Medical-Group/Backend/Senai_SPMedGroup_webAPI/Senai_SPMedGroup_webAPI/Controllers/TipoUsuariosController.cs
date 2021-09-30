using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using Senai_SPMedGroup_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoUsuarioRepository que irá receber todos os métodos definidos na interface ITipoUsuarioRepository
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tipoUsuarioRepository para que haja referência às implementações feitas no repositório TipoUsuarioRepository
        /// </summary>
        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }
        /// <summary>
        /// Lista todos os TiposUsuarios
        /// </summary>
        /// <returns>Uma lista de tipos Usuarios com o status code 200 - Ok</returns>
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
        /// Busca um Tipo Usuário através do seu id
        /// </summary>
        /// <param name="IdTipoUsuario">ID do TipoUsuario que será buscado</param>
        /// <returns> Um TipoUsuario encontrada com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{IdTipoUsuario}")]
        public IActionResult BuscarPorId(int IdTipoUsuario)
        {

            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarId(IdTipoUsuario);
            if (tipoUsuarioBuscado == null)
            {
                return NotFound
                        (new
                        {
                            mensagem = "Tipos Usuários não encontrada!",
                            erro = true
                        });
            }
            try
            {
                // Retorna um Tipo Usuário encontrada
                return Ok(tipoUsuarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra um Tipo Usuário
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
        /// Atualiza um Tipo Usuário existente
        /// </summary>
        /// <param name="IdTipoUsuario">ID do Tipo de Usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizada com as novas informações</param>
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
                        mensagem = "Tipo Usuario não encontrado!",
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
        /// Deleta um Tipo de Usuário existente
        /// </summary>
        /// <param name="IdTipoUsuario">ID do Tipo Usuario que será deletado</param>
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
            return NotFound("Nenhum Tipo de Usuário foi encontrado!");
        }
    }
}
