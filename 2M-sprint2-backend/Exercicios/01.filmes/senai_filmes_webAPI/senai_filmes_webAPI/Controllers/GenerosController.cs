using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Controlador Responsável pelo end points referentes aos gêneros
/// </summary>
namespace senai_filmes_webAPI.Controllers
{
    // Define que io tipo de resposta da API será no Formato JSON
    [Produces("application/json")]


    // Define que a rota de uma requisição será no formato dominio/api/nomeController.
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]
    // Define que é um controlador de API.
    [ApiController]
    public class GenerosController : ControllerBase
    {

        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _GeneroRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _GeneroRepository para que haja a referência dos metodos no repositório
        /// </summary>
        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();

        }

        [HttpGet]

        // IActionResult = Resultado de uma ação
        // Get() = nome generico
        public IActionResult Get()
        {

            // Lista de gêneros 
            // se conectar com o Repositório.

            // Criar uma lista nomeada listaGeneros para receber os dados.
            List<GeneroDomain> listaGenero = _GeneroRepository.ListarTodos();


            // Retorna o status code 200(OK) com a lista generos no formato JSON
            return Ok(listaGenero);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum gênero encontrado!");
            }

            return Ok(generoBuscado);
        }


        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // Fazer a chamada para o método .Cadastrar();
            _GeneroRepository.Cadastrar(novoGenero);

            // Retorna Status Code 201 - Created.
            return StatusCode(201);

        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _GeneroRepository.AtualizarIdUrl(id, generoAtualizado);

                return NoContent();

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody (GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(generoAtualizado.idGenero);
            
            if (generoBuscado != null)
            {
                try
                {
                    _GeneroRepository.AtualizarIdCorpo(generoAtualizado);


                    return NoContent();
                }
                catch (Exception ex)
                {

                    return BadRequest(ex);
                }
            }
            return NotFound(
                new
                {
                    mensagemErro = "Gênero não encontrado",
                    codErro = true
                }

                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _GeneroRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
