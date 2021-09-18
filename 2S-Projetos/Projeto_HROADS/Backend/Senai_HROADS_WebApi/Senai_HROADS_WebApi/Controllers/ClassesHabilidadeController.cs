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
    public class ClassesHabilidadeController : ControllerBase
    {
        /// <summary>
        ///  Objeto _ClasseHabilidadeRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>

        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _classeHabilidadeRepositor para que haja referência às implementações feitas no repositório ClasseHabilidadeRepository
        /// </summary>
        public ClassesHabilidadeController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os ClasseHabilidadeRepository
        /// </summary>
        /// <returns>Uma lista de ClasseHabilidade com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<ClasseHabilidade> listaClasseHabilidade = _classeHabilidadeRepository.ListarTodos();
                return Ok(listaClasseHabilidade);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Busca um ClasseHabilidade através do seu id
        /// </summary>
        /// <param name="Id">ID do classeHabilidade que será buscado</param>
        /// <returns>Um ClasseHabilidade encontrado com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {     
            try
            {
                ClasseHabilidade classeHabilidadeBuscado = _classeHabilidadeRepository.BuscarId(Id);
                // Retorna um Classe Habilidade encontrado
                return Ok(classeHabilidadeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra uma ClasseHabilidade
        /// </summary>
        /// <param name="novoClasseHabilidade">Objeto novoClasseHabilidade com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(ClasseHabilidade novoClasseHabilidade)
        {
            // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
            try
            {
                _classeHabilidadeRepository.Cadastrar(novoClasseHabilidade);
                // Retorna um status code 201
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um ClasseHabilidade existente
        /// </summary>
        /// <param name="Id">ID do Classe Habilidade que será atualizado</param>
        /// <param name="classeHabilidadeAtualizado">Objeto classeHabilidadeAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, ClasseHabilidade classeHabilidadeAtualizado)
        {
            ClasseHabilidade classeHabilidadeBuscado = _classeHabilidadeRepository.BuscarId(Id);
            if (classeHabilidadeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "ClasseHabilidade não encontrada!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _classeHabilidadeRepository.Atualizar(Id, classeHabilidadeAtualizado);

                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);

            }
        }

        /// <summary>
        /// Deleta um Classe Habilidade existente
        /// </summary>
        /// <param name="Id">ID do Classe Habilidadee que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {       
            // Faz a chamada para o método .Deletar enviando o id da Classe como parâmetro
            ClasseHabilidade classeHabilidadeBuscado = _classeHabilidadeRepository.BuscarId(Id);
            if (classeHabilidadeBuscado != null)
            {
                try
                {
                    _classeHabilidadeRepository.Deletar(Id);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhuma Classe_Habilidade foi encontrado!");
        }

    }
}
