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

    public class DesejosController : ControllerBase
    {
        private  IDesejoRepository _DesejoRepository { get; set; }


        public DesejosController()
        {
            _DesejoRepository = new DesejoRepository();
        }
        

        [HttpGet]
        public IActionResult ListarTodosDesejos()
        {
            try
            {
                return Ok(_DesejoRepository.ListarDesejos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }


        [HttpPost]
        public IActionResult Cadastrar(Desejo NovoDesejo)
        {
            try
            {
                _DesejoRepository.Cadastrar(NovoDesejo);

                return Ok();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }
    }
}
