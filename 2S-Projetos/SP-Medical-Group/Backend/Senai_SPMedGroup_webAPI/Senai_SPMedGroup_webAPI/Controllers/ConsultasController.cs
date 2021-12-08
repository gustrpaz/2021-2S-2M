using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using Senai_SPMedGroup_webAPI.Repositories;
using Senai_SPMedGroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        //   IdTipoUsuario
        // 1 - Administrador
        // 2 - Médico
        // 3 - Paciente

        // Controller responsável pelos endpoints (URLs) referentes as Consultas
        /// <summary>
        /// Objeto _consultaRepository que irá receber todos os métodos definidos na interface IConsultaRepository
        /// </summary>
        private IConsultaRepository _consultaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _consultaRepository para que haja referência às implementações feitas no repositório ConsultaRepository
        /// </summary>
        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }
        /// <summary>
        /// Lista todos as Consultas
        /// </summary>
        /// <returns> Uma lista de consulta com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Consulta> listaConsulta = _consultaRepository.ListarTodos();
                return Ok(listaConsulta);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma Consulta através do seu id
        /// </summary>
        /// <param name="IdConsulta">ID da consulta que será buscado</param>
        /// <returns> Uma consulta encontrada com o status code 200 - Ok</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpGet("buscar/{IdConsulta}")]
        public IActionResult BuscarPorId(int IdConsulta)
        {

            Consulta consultaBuscada = _consultaRepository.BuscarId(IdConsulta);
            if (consultaBuscada == null)
            {
                return NotFound
                        (new
                        {
                            mensagem = "Consulta não encontrada!",
                            erro = true
                        });
            }
            try
            {
                // Retorna uma Consulta encontrada
                return Ok(consultaBuscada);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra uma Consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(ConsultaViewModel novaConsulta)
        {
            try
            {
                Consulta newConsulta = new Consulta();

                newConsulta.IdPaciente = novaConsulta.IdPaciente;
                newConsulta.IdMedico = novaConsulta.IdMedico;
                newConsulta.IdSituacao = novaConsulta.IdSituacao;
                newConsulta.DataHora = novaConsulta.DataHora;
                newConsulta.Descricao = novaConsulta.Descricao;

                _consultaRepository.Cadastrar(newConsulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza uma Consulta existente
        /// </summary>
        /// <param name="IdConsulta">ID da Consulta que será atualizado</param>
        /// <param name="consultaAtualizada">Objeto consultaAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPut("{IdConsulta}")]
        public IActionResult Atualizar(int IdConsulta, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = _consultaRepository.BuscarId(IdConsulta);
            if (consultaBuscada == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Consulta não encontrado!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _consultaRepository.Atualizar(IdConsulta, consultaAtualizada);
                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } 

        /// <summary>
        /// Função para o médico alterar o estado de uma consulta
        /// </summary>
        /// <param name="IdConsulta"></param>
        /// <param name="consultaAtualizada"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPatch("{IdConsulta}")]
        public IActionResult SituacaoConsulta(int IdConsulta, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = _consultaRepository.BuscarId(IdConsulta);
            if (consultaBuscada == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Consulta não pode ser encontrada!",
                        erro = true
                    });
            }
            try
            {
                // Faz a chamada para o método .Atualizar enviando as novas informações
                _consultaRepository.SituacaoConsulta(IdConsulta, consultaAtualizada);
                // Retorna um status code 204
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Deleta uma Consulta existente
        /// </summary>
        /// <param name="IdConsulta">ID da Clínica que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// 
        [Authorize(Roles = "1")]
            [HttpDelete("{IdConsulta}")]
            public IActionResult Deletar(int IdConsulta)
            {
                Consulta consultaBuscada = _consultaRepository.BuscarId(IdConsulta);
                if (consultaBuscada != null)
                {
                    try
                    {
                        _consultaRepository.Deletar(IdConsulta);
                        return StatusCode(204);
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro);
                    }
                }
                return NotFound("Nenhuma Consulta foi encontrada!");
            }

        /// <summary>
        /// Método para o paciente listar suas consultas 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1,2,3")]
        [HttpGet("minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhas(IdUsuario));
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível listar as consultas se o usuário não estiver logado!"

                });
            }
          
        }
        /// <summary>
        /// Função para listar as consultas de um médico
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet("minhasMed")]
        public IActionResult ListarMinhasMed()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhasMed(IdUsuario));
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível listar as consultas se o usuário não estiver logado!"

                });
            }
        }

        [Authorize(Roles = "2")]
        [HttpPatch("AlterarDescricao/{IdConsulta}")]
        public IActionResult AlterarDescricao(Consulta consultaAtt, int IdConsulta)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarId(IdConsulta);
                int IdMedico = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                if (consultaAtt.Descricao == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "É necessário informar a descrição!"
                    });
                }


                if (_consultaRepository.BuscarId(IdConsulta) == null)
                {
                    return NotFound(new
                    {
                        Mensagem = "Não há nenhuma consulta com o ID informado!"
                    });
                }

               
                _consultaRepository.AlterarDescricao(consultaAtt.Descricao, IdConsulta);
                return StatusCode(200, new
                {
                    Mensagem = "A descrição da consulta foi alterada com sucesso!",
                    consultaBuscada
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "1,2,3")]
        [HttpGet("minhasMobile")]
        public IActionResult ListarMinhasMobile()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhasMobile(IdUsuario));
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível listar as consultas se o usuário não estiver logado!"

                });
            }

        }


    }
}
