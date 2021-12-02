using System;
using System.Collections.Generic;

#nullable disable

namespace senai_roman_webAPI.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoUsuario { get; set; }
        public string TituloUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
