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

    //Define que a rota de uma requisição será no formato dominio/api/nomeController.
    // ex: http://localhost:5000/api/clientes
    [Route("api/[controller]")]
    //Define que é um controlador de API.
    [ApiController]
    public class ClientesController : Controller
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();

        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaCliente = _ClienteRepository.ListarTodos();

            // Retorna o status code 200(OK) com a lista clientes no formato JSON
            return Ok(listaCliente);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound("Nenhum cliente encontrado!");
            }

            return Ok(clienteBuscado);
        }


        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            // Fazer a chamada para o método .Cadastrar();
            _ClienteRepository.Cadastrar(novoCliente);

            // Retorna Status Code 201 - Created.
            return StatusCode(201);

        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, ClienteDomain clienteAtualizado)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Cliente não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _ClienteRepository.AtualizarIdUrl(id, clienteAtualizado);

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
            _ClienteRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
