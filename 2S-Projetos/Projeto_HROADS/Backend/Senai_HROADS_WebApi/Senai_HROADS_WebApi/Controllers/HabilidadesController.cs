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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }



        //Listar Todos
        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>uma lista de habilidades e um status code</returns>
        /// PÚBLICA
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Habilidade> listaHabilidade = _habilidadeRepository.ListarTodos();
                return Ok(listaHabilidade);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



        //Cadastrar
        /// <summary>
        /// Cadastra uma habilidade
        /// </summary>
        /// <param name="novaHabiliade">novo objeto que será cadastrado</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novaHabiliade)
        {                   
            try
            {
                // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
                _habilidadeRepository.Cadastrar(novaHabiliade);
                // Retorna um status code 201
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //  Deletar
        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">id da habilidade que será deletada</param>
        /// <returns>retorna um status code</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {        
            // Faz a chamada para o método .Deletar enviando o id da Classe como parâmetro
            Habilidade habilidadeBuscado = _habilidadeRepository.BuscarId(id);
            if (habilidadeBuscado != null)
            {
                try
                {
                    _habilidadeRepository.Deletar(id);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhuma Habilidade foi encontrado!");
        }


        //Atualizar
        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">id da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">objeto habilidade atualizado</param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscado = _habilidadeRepository.BuscarId(id);
            if (habilidadeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Habilidade não encontrada!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);

            }
        }


        //BuscarId
        /// <summary>
        /// Busca uma habilidade pelo seu id
        /// </summary>
        /// <param name="id">id da habilidade que será buscada</param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                Habilidade habilidadeBuscado = _habilidadeRepository.BuscarId(id);
                // Retorna uma Habilidade encontrado
                return Ok(habilidadeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
