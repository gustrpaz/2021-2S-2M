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
    public class PacientesController : ControllerBase
    {
        /// <summary>
        /// Objeto _pacienteRepository que irá receber todos os métodos definidos na interface IPacienteRepository
        /// </summary>
        private IPacienteRepository _pacienteRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _pacienteRepository para que haja referência às implementações feitas no repositório PacienteRepository
        /// </summary>
        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }
        /// <summary>
        /// Lista todos os Pacientes
        /// </summary>
        /// <returns> Uma lista de pacientes com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Paciente> listaPaciente = _pacienteRepository.ListarTodos();
                return Ok(listaPaciente);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um Paciente através do seu id
        /// </summary>
        /// <param name="IdPaciente">ID da paciente que será buscado</param>
        /// <returns> Um paciente encontrado com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1,2")]
        [HttpGet("{IdPaciente}")]
        public IActionResult BuscarPorId(int IdPaciente)
        {

            Paciente pacienteBuscado = _pacienteRepository.BuscarId(IdPaciente);
            if (pacienteBuscado == null)
            {
                return NotFound
                        (new
                        {
                            mensagem = "Paciente não encontrado!",
                            erro = true
                        });
            }
            try
            {
                // Retorna um Paciente encontrado
                return Ok(pacienteBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra um Paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto novoPaciente com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Paciente novoPaciente)
        {
            try
            {
                // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
                _pacienteRepository.Cadastrar(novoPaciente);
                // Retorna um status code 201
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um Paciente existente
        /// </summary>
        /// <param name="IdPaciente">ID do Paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">Objeto pacienteAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{IdPaciente}")]
        public IActionResult Atualizar(int IdPaciente, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = _pacienteRepository.BuscarId(IdPaciente);
            if (pacienteBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Paciente não encontrado!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _pacienteRepository.Atualizar(IdPaciente, pacienteAtualizado);
                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um Paciente existente
        /// </summary>
        /// <param name="IdPaciente">ID da Paciente que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{IdPaciente}")]
        public IActionResult Deletar(int IdPaciente)
        {
            Paciente pacienteBuscado = _pacienteRepository.BuscarId(IdPaciente);
            if (pacienteBuscado != null)
            {
                try
                {
                    _pacienteRepository.Deletar(IdPaciente);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhum Paciente foi encontrado!");

        }
    }
}
