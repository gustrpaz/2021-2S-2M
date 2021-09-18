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
    public class ClassesController : ControllerBase
    {
        /// <summary>
        /// Objeto _classeRepository que irá receber todos os métodos definidos na interface IClasseRepository
        /// </summary>
        private IClasseRepository _classeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _classeRepository para que haja referência às implementações feitas no repositório ClasseRepository
        /// </summary>
        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todos as Classes
        /// </summary>
        /// <returns>Uma lista de Classes com o status code 200 - Ok</returns>
        /// PÚBLICA
        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Listar()
        {      
            try
            {
                List<Classe> listaClasse = _classeRepository.ListarTodos();
                return Ok(listaClasse);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Busca uma classe através do seu id
        /// </summary>
        /// <param name="IdClasse">ID da Classe que será buscado</param>
        /// <returns>Uma classe encontrado com o status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{IdClasse}")]
        public IActionResult BuscarId(int IdClasse)
        {
            // Retorna uma Classe encontrada
            try
            {
                Classe classeBuscado = _classeRepository.BuscarId(IdClasse);
                return Ok(classeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra uma Classe
        /// </summary>
        /// <param name="novoClasse">Objeto novoClasse com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Classe novoClasse)
        {
            // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
            try
            {
                _classeRepository.Cadastrar(novoClasse);
                // Retorna um status code 201
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="IdClasse">ID da classe que será atualizado</param>
        /// <param name="classeAtualizado">Objeto classeAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{IdClasse}")]
        public IActionResult Atualizar(int IdClasse, Classe classeAtualizado)
        {

            Classe classeBuscado = _classeRepository.BuscarId(IdClasse);


            if (classeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Classe não encontrada!",
                        erro = true
                    }); 
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _classeRepository.Atualizar(IdClasse, classeAtualizado);

                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
              
            }
  
        }

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="IdClasse">ID da Classe que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{IdClasse}")]
        public IActionResult Deletar(int IdClasse)
        {
            // Faz a chamada para o método .Deletar enviando o id da Classe como parâmetro
            Classe classeBuscado = _classeRepository.BuscarId(IdClasse);

            if (classeBuscado != null)
            {
                try
                {
                    _classeRepository.Deletar(IdClasse);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound("Nenhuma classe foi encontrado!");
        }
    }
}
