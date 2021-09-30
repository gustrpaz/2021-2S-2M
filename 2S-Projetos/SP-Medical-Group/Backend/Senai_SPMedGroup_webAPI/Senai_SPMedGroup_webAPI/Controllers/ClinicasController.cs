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
    // Controller responsável pelos endpoints (URLs) referentes as Clínicas
    public class ClinicasController : ControllerBase
    {
        /// <summary>
        /// Objeto _clinicaRepository que irá receber todos os métodos definidos na interface IClinicaRepository
        /// </summary>
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _clinicaRepository para que haja referência às implementações feitas no repositório ClinicaRepository
        /// </summary>
        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }
        /// <summary>
        /// Lista todos as Clínicas
        /// </summary>
        /// <returns>Uma lista de clínicas com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1,2,3")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Clinica> listaClinica = _clinicaRepository.ListarTodos();
                return Ok(listaClinica);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma Clínica através do seu id
        /// </summary>
        /// <param name="IdClinica">ID da clinica que será buscado</param>
        /// <returns> Uma clínica encontrada com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1,2,3")]
        [HttpGet("{IdClinica}")]
        public IActionResult BuscarPorId(int IdClinica)
        {

           Clinica clinicaBuscada = _clinicaRepository.BuscarId(IdClinica);
            if (clinicaBuscada == null)
            {
                return NotFound
                        (new
                        {
                            mensagem = "Clínica não encontrada!",
                            erro = true
                        });
            }
            try
            {
                // Retorna uma Clínica encontrada
                return Ok(clinicaBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra uma Clínica
        /// </summary>
        /// <param name="novaClinica">Objeto novaClinica com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaClinica)
        {
            try
            {
                // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
                _clinicaRepository.Cadastrar(novaClinica);
                // Retorna um status code 201
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza uma Clínica existente
        /// </summary>
        /// <param name="IdClinica">ID da Clínica que será atualizado</param>
        /// <param name="clinicaAtualizada">Objeto clinicaAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{IdClinica}")]
        public IActionResult Atualizar(int IdClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = _clinicaRepository.BuscarId(IdClinica);
            if (clinicaBuscada == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Clínica não encontrado!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _clinicaRepository.Atualizar(IdClinica, clinicaAtualizada);
                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma Clínica existente
        /// </summary>
        /// <param name="IdClinica">ID da Clínica que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{IdClinica}")]
        public IActionResult Deletar(int IdClinica)
        {
            Clinica clinicaBuscada = _clinicaRepository.BuscarId(IdClinica);
            if (clinicaBuscada != null)
            {
                try
                {
                    _clinicaRepository.Deletar(IdClinica);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhuma Clínica foi encontrada!");
        }
    }
}

