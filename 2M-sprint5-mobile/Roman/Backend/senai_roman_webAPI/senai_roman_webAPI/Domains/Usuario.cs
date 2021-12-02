using System;
using System.Collections.Generic;

#nullable disable

namespace senai_roman_webAPI.Domains
{
    public partial class Usuario
    {
        public byte IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
