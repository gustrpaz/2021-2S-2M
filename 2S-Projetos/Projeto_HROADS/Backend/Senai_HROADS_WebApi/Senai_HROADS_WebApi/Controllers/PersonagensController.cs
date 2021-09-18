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
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }


        //ListarTodos
        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>uma lista de estudios com status code</returns>
        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Personagem> listaPersonagem = _personagemRepository.ListarTodos();
                return Ok(listaPersonagem);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //Cadastrar
        /// <summary>
        /// cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">objeto personagem com as ionformações</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            try
            {
                // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
                _personagemRepository.Cadastrar(novoPersonagem);
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
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">id do personagem que será deletado</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Personagem personagemBuscado = _personagemRepository.BuscarId(id);
            if (personagemBuscado != null)
            {
                try
                {
                    _personagemRepository.Deletar(id);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhum personagem foi encontrado!");
        }

        //Atualizar
        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="id">id do personagem que será atualizado</param>
        /// <param name="personagemAtualizado">objeto Personagem com as informações novas</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = _personagemRepository.BuscarId(id);
            if (personagemBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Personagem não encontrado!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _personagemRepository.Atualizar(id, personagemAtualizado);
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
        /// Busca um personagem pelo seu id
        /// </summary>
        /// <param name="id">id do personagem que será buscado</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
               Personagem personagemBuscado = _personagemRepository.BuscarId(id);
                // Retorna um Personagem encontrado
                return Ok(personagemBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
