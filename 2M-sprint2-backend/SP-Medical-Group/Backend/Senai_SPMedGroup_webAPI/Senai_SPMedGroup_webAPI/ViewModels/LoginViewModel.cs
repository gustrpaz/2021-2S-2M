using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.ViewModels
{

    /// <summary>
    /// Responsável pelo modelo de Login
    /// </summary>
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }
    }
}
