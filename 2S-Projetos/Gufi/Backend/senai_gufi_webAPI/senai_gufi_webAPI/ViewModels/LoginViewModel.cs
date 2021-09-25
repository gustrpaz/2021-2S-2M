using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.ViewModels
{
    public class LoginViewModel
    {
        /// <summary>
        /// Classe responsável pelo modelo de Login
        /// </summary>
             
            [Required(ErrorMessage = "Informe o e-mail do usuário!")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Informe a senha do usuário!")]
            public string Senha { get; set; }

        }
}
