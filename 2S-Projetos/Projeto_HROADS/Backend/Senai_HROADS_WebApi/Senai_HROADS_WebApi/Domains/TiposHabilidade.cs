using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_HROADS_WebApi.Domains
{
    public partial class TiposHabilidade
    {
        public TiposHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipos { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
