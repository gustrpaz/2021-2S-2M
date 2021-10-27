using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_WishList_webApi.Domains;
using senai_WishList_webApi.Interfaces;
using senai_WishList_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_WishList_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }


        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodosUsuarios()
        {
            try
            {
                return Ok(_UsuarioRepository.ListarUsuarios());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }


        [HttpPost]
        public IActionResult Cadastrar(Usuario NovoUsuario)
        {
            try
            {
                _UsuarioRepository.Cadastrar(NovoUsuario);

                return Ok();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }
    }
}
