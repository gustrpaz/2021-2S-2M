using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Controllers
{ 

        [Produces("application/json")]

        [Route("api/[controller]")]
        // Define que é um controlador de API.
        [ApiController]

    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _FilmeRepository { get; set; }

        public FilmesController()
        {
            _FilmeRepository = new FilmeRepository();

        }

        [HttpGet]

        // IActionResult = Resultado de uma ação
        // Get() = nome generico
        public IActionResult Get()
        {
            // Lista de gêneros 
            // se conectar com o Repositório.

            // Criar uma lista nomeada listaGeneros para receber os dados.
            List<FilmeDomain> listaFilme = _FilmeRepository.ListarTodos();


            // Retorna o status code 200(OK) com a lista generos no formato JSON
            return Ok(listaFilme);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            // Fazer a chamada para o método .Cadastrar();
            _FilmeRepository.Cadastrar(novoFilme);

            // Retorna Status Code 201 - Created.
            return StatusCode(201);

        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            FilmeDomain filmeBuscado = _FilmeRepository.BuscarPorId(id);

            if (filmeBuscado == null)
            {
                return NotFound("Nenhum filme encontrado!");
            }

            return Ok(filmeBuscado);
        }


        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _FilmeRepository.BuscarPorId(id);

            if (filmeBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Filme não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _FilmeRepository.AtualizarIdUrl(id, filmeAtualizado);

                return NoContent();

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _FilmeRepository.BuscarPorId(filmeAtualizado.idFilme);

            if (filmeBuscado != null)
            {
                try
                {
                    _FilmeRepository.AtualizarIdCorpo(filmeAtualizado);


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
                    mensagemErro = "Filme não encontrado",
                    codErro = true
                }

                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _FilmeRepository.Deletar(id);

            return StatusCode(204);
        }
    }


}

