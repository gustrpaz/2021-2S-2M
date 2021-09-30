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
    public class MedicosController : ControllerBase
    {
        /// <summary>
        /// Objeto _medicoRepository que irá receber todos os métodos definidos na interface IMedicoRepository
        /// </summary>
        private IMedicoRepository _medicoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _medicoRepository para que haja referência às implementações feitas no repositório medicoRepository
        /// </summary>
        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }
        /// <summary>
        /// Lista todos os Médicos
        /// </summary>
        /// <returns>Uma lista de médicos com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Medico> listaMedico = _medicoRepository.ListarTodos();
                return Ok(listaMedico);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um Médico através do seu id
        /// </summary>
        /// <param name="IdMedico">ID do Médico que será buscado</param>
        /// <returns> Um médico encontrada com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{IdMedico}")]
        public IActionResult BuscarPorId(int IdMedico)
        {

            Medico medicoBuscado = _medicoRepository.BuscarId(IdMedico);
            if (medicoBuscado == null)
            {
                return NotFound
                        (new
                        {
                            mensagem = "Médicos não encontrado!",
                            erro = true
                        });
            }
            try
            {
                // Retorna um Médico encontrado
                return Ok(medicoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra um Médico
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            try
            {
                // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
                _medicoRepository.Cadastrar(novoMedico);
                // Retorna um status code 201
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um Médico existente
        /// </summary>
        /// <param name="IdMedico">ID do médico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto medicoAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{IdMedico}")]
        public IActionResult Atualizar(int IdMedico, Medico medicoAtualizado)
        {
            Medico medicoBuscado = _medicoRepository.BuscarId(IdMedico);
            if (medicoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Médico não encontrado!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _medicoRepository.Atualizar(IdMedico, medicoAtualizado);
                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um Médico existente
        /// </summary>
        /// <param name="IdMedico">ID do médico que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{IdMedico}")]
        public IActionResult Deletar(int IdMedico)
        {
            Medico medicoBuscado = _medicoRepository.BuscarId(IdMedico);
            if (medicoBuscado != null)
            {
                try
                {
                    _medicoRepository.Deletar(IdMedico);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhum Médico foi encontrado!");
        }
    }
}
