using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_roman_webAPI.Domains;
using senai_roman_webAPI.Interfaces;
using senai_roman_webAPI.Repositories;
using senai_spmed_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método de login
        /// </summary>
        /// <param name="login">objeto loginViewModel</param>
        /// <returns>JWT</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario UsuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (UsuarioBuscado == null)
                {
                    return BadRequest("Usuario ou senha inválidos");
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.EmailUsuario),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuario.ToString()),

                    new Claim("role", UsuarioBuscado.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(

                    issuer: "roman.webAPI",
                    audience: "roman.webAPI",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
