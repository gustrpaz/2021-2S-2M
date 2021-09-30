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
    public class SituacoesController : ControllerBase
    {

        /// <summary>
        /// Objeto _situacaoRepository que irá receber todos os métodos definidos na interface ISituacaoRepository
        /// </summary>
        private ISituacaoRepository _situacaoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _situacaoRepository para que haja referência às implementações feitas no repositório SituacaoRepository
        /// </summary>
        public SituacoesController()
        {
            _situacaoRepository = new SituacaoRepository();
        }


        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Situacao> listaSituacao = _situacaoRepository.ListarTodos();
                return Ok(listaSituacao);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma situacao através do seu id
        /// </summary>
        /// <param name="IdSituacao">ID da Situacao que será buscado</param>
        /// <returns> Uma Situacao encontrada com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("{IdSituacao}")]
        public IActionResult BuscarPorId(int IdSituacao)
        {

            Situacao situacaoBuscado = _situacaoRepository.BuscarId(IdSituacao);
            if (situacaoBuscado == null)
            {
                return NotFound
                        (new
                        {
                            mensagem = "situações não encontrada!",
                            erro = true
                        });
            }
            try
            {
                // Retorna uma situacao encontrada
                return Ok(situacaoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }


        /// <summary>
        /// Atualiza uma situacao existente
        /// </summary>
        /// <param name="IdSituacao">ID da Situação que será atualizado</param>
        /// <param name="situacaoAtualizado">Objeto situacaoAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{IdSituacao}")]
        public IActionResult Atualizar(int IdSituacao, Situacao situacaoAtualizado)
        {
            Situacao situacaoBuscado = _situacaoRepository.BuscarId(IdSituacao);
            if (situacaoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Situação não encontrada!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _situacaoRepository.Atualizar(IdSituacao, situacaoAtualizado);
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
