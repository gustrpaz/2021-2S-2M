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
    public class TiposHabilidadesController : ControllerBase
    {
        private ITiposHabilidadeRepository _tiposHabilidadeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _classeHabilidadeRepositor para que haja referência às implementações feitas no repositório ClasseHabilidadeRepository
        /// </summary>
        public TiposHabilidadesController()
        {
            _tiposHabilidadeRepository = new TipoHabilidadeRepository();
        }

        
        //Listar Todos
        /// <summary>
        /// Lista todos os tiposHabilidade
        /// </summary>
        /// <returns>Uma lista de TiposHabilidade com o status code 200 - Ok</returns>
        /// PÚBLICA
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<TiposHabilidade> listaTiposHabilidade = _tiposHabilidadeRepository.ListarTodos();
                return Ok(listaTiposHabilidade);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        //Cadastrar
        /// <summary>
        /// Cadastra um TipoHabilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto novoTipoHabilidade com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TiposHabilidade novoTipoHabilidade)
        {       
            try
            {
                // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
                _tiposHabilidadeRepository.Cadastrar(novoTipoHabilidade);
                // Retorna um status code 201
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }


        //Deletar
        /// <summary>
        /// Deleta um tipo Habilidade existente
        /// </summary>
        /// <param name="Id">ID do tipo Habilidadee que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            TiposHabilidade tiposHabilidadeBuscado = _tiposHabilidadeRepository.BuscarId(Id);
            if (tiposHabilidadeBuscado != null)
            {
                try
                {
                    _tiposHabilidadeRepository.Deletar(Id);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhum Tipo Habilidade foi encontrado!");
        }


        //Buscar ID
        /// <summary>
        /// Busca um TipoHabilidade através do seu id
        /// </summary>
        /// <param name="Id">ID do TipoHabilidade que será buscado</param>
        /// <returns>Um TipoHabilidade encontrado com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            try
            {
                TiposHabilidade tiposHabilidadeBuscado = _tiposHabilidadeRepository.BuscarId(Id);
                // Retorna um tipo Habilidade encontrado
                return Ok(tiposHabilidadeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //Atualizar
        /// <summary>
        /// Atualiza um TipoHabilidade existente
        /// </summary>
        /// <param name="Id">ID do TipoHabilidade que será atualizado</param>
        /// <param name="tipoHabilidadeAtualizado">Objeto TipoHabilidadeAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id,TiposHabilidade tipoHabilidadeAtualizado)
        {     
           TiposHabilidade tiposHabilidadeBuscado = _tiposHabilidadeRepository.BuscarId(Id);
            if (tiposHabilidadeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "tipos de habilidade não encontrado!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _tiposHabilidadeRepository.Atualizar(Id, tipoHabilidadeAtualizado);
                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
