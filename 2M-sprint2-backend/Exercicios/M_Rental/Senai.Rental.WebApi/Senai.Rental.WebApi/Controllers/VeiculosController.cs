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
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController.
    // ex: http://localhost:5000/api/veiculos
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : Controller
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        // IActionResult = Resultado de uma ação
        // Get() = nome generico
        public IActionResult Get()
        {
            // Criar uma lista nomeada listaVeiculos para receber os dados.
            List<VeiculoDomain> listaVeiculo = _VeiculoRepository.ListarTodos();

            // Retorna o status code 200(OK) com a lista veiculo no formato JSON
            return Ok(listaVeiculo);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain veiculoBuscado = _VeiculoRepository.BuscarPorId(id);

            if (veiculoBuscado == null)
            {
                return NotFound("Nenhum veículo encontrado!");
            }

            return Ok(veiculoBuscado);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            // Fazer a chamada para o método .Cadastrar();
            _VeiculoRepository.Cadastrar(novoVeiculo);

            // Retorna Status Code 201 - Created.
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, VeiculoDomain veiculoAtualizado)
        {
            VeiculoDomain veiculoBuscado = _VeiculoRepository.BuscarPorId(id);

            if (veiculoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Veículo não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _VeiculoRepository.AtualizarIdUrl(id, veiculoAtualizado);

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
            _VeiculoRepository.Deletar(id);

            return StatusCode(204);
        }

    }
}
