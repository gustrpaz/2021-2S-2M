using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMedGroup_webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            ImagemUsuarios = new HashSet<ImagemUsuario>();
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O email é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(30, MinimumLength = 5, ErrorMessage ="O mínimo de caracteres é 30")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<ImagemUsuario> ImagemUsuarios { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
