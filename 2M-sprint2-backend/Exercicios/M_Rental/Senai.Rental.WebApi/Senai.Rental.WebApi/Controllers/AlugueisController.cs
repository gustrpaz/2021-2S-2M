using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    // Define que io tipo de resposta da API será no Formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController.
    // ex: http://localhost:5000/api/alugueis
    [Route("api/[controller]")]
    // Define que é um controlador de API.
    [ApiController]
    public class AlugueisController : Controller
    {

        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IAluguelRepository _AluguelRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _AluguelRepository para que haja a referência dos metodos no repositório
        /// </summary>
        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        // IActionResult = Resultado de uma ação
        // Get() = nome generico
        public IActionResult Get()
        {
            // Lista de Alugueis
            // se conectar com o Repositório.

            // Criar uma lista nomeada listAlguel para receber os dados.
            List<AluguelDomain> listaAluguel = _AluguelRepository.ListarTodos();

            // Retorna o status code 200(OK) com a lista aluguel no formato JSON
            return Ok(listaAluguel);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (aluguelBuscado == null)
            {
                return NotFound("Nenhum aluguel encontrado!");
            }

            return Ok(aluguelBuscado);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            // Fazer a chamada para o método .Cadastrar();
            _AluguelRepository.Cadastrar(novoAluguel);

            // Retorna Status Code 201 - Created.
            return StatusCode(201);

        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, AluguelDomain aluguelAtualizado)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (aluguelBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Aluguel não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _AluguelRepository.AtualizarIdUrl(id, aluguelAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _AluguelRepository.Deletar(id);

            return StatusCode(204);
        }

    }
}
