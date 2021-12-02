using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_roman_webAPI.Domains;
using senai_roman_webAPI.Interfaces;
using senai_roman_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_roman_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private IProjetoRepository _projetoRepository { get; set; }

        public ProjetosController()
        {
            _projetoRepository = new ProjetoRepository();
        }

        /// <summary>
        /// Lista todos os projetos
        /// </summary>
        /// <returns>Uma lista de projetos</returns>
        /// 
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_projetoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo projeto
        /// </summary>
        /// <param name="novoProjeto">Um objeto com as propriedades a serem cadastradas</param>
        /// <returns>status code 201 created</returns>
        /// 
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Projeto novoProjeto)
        {
            try
            {
                _projetoRepository.Cadastrar(novoProjeto);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
