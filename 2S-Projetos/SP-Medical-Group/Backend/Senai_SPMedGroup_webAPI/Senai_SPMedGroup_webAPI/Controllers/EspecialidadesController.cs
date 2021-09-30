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
    public class EspecialidadesController : ControllerBase
    {

        /// <summary>
        /// Objeto _especialidadeRepository que irá receber todos os métodos definidos na interface IEspecialidadeRepository
        /// </summary>
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _especialidadeRepository para que haja referência às implementações feitas no repositório EspecialidadeRepository
        /// </summary>
        public EspecialidadesController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }
        /// <summary>
        /// Lista todos as Especialidades
        /// </summary>
        /// <returns> Uma lista de especialidades com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Especialidade> listaEspecialidade = _especialidadeRepository.ListarTodos();
                return Ok(listaEspecialidade);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma Especialidade através do seu id
        /// </summary>
        /// <param name="IdEspecialidade">ID da especialidade que será buscado</param>
        /// <returns> Uma especialidade encontrada com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{IdEspecialidade}")]
        public IActionResult BuscarPorId(int IdEspecialidade)
        {

            Especialidade especialidadeBuscada = _especialidadeRepository.BuscarId(IdEspecialidade);
            if (especialidadeBuscada == null)
            {
                return NotFound
                        (new
                        {
                            mensagem = "Especialidade não encontrada!",
                            erro = true
                        });
            }
            try
            {
                // Retorna uma Especialidade encontrada
                return Ok(especialidadeBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra uma Especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto novaEspecialidade com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Especialidade novaEspecialidade)
        {
            try
            {
                // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
                _especialidadeRepository.Cadastrar(novaEspecialidade);
                // Retorna um status code 201
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza uma Especialidade existente
        /// </summary>
        /// <param name="IdEspecialidade">ID da Especialidade que será atualizado</param>
        /// <param name="especialidadeAtualizada">Objeto especialidadeAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{IdEspecialidade}")]
        public IActionResult Atualizar(int IdEspecialidade, Especialidade especialidadeAtualizada)
        {
            Especialidade especialidadeBuscada = _especialidadeRepository.BuscarId(IdEspecialidade);
            if (especialidadeBuscada == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Especialidade não encontrada!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _especialidadeRepository.Atualizar(IdEspecialidade, especialidadeAtualizada);
                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma Especialidade existente
        /// </summary>
        /// <param name="IdEspecialidade">ID da Especialidade que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpDelete("{IdEspecialidade}")]
        public IActionResult Deletar(int IdEspecialidade)
        {
            Especialidade especialidadeBuscada = _especialidadeRepository.BuscarId(IdEspecialidade);
            if (especialidadeBuscada != null)
            {
                try
                {
                    _especialidadeRepository.Deletar(IdEspecialidade);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound("Nenhuma Especialidade foi encontrada!");

        }
    }
}
