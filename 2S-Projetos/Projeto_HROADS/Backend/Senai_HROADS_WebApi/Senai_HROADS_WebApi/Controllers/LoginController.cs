using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_HROADS_WebApi.Domains;
using Senai_HROADS_WebApi.Interfaces;
using Senai_HROADS_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]

  public class LoginController : ControllerBase
   {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public LoginController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }



        /// <summary>
        /// Autentica um usuário
        /// </summary>
        /// <param name = "login" ></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _UsuarioRepository.Login(login.Email, login.Senha);

            if (usuarioBuscado != null)
            {
                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Hroads-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Hroads.WebApi",

                    audience: "Hroads.WebApi",

                    claims: Claims,

                    expires: DateTime.Now.AddHours(1),

                    signingCredentials: creds
                    );


                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                    );
            }


            return NotFound("Email ou senha inválidos!");
        }

    }

}
