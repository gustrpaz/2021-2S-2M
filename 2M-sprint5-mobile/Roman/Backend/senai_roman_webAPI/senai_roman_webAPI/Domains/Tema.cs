using System;
using System.Collections.Generic;

#nullable disable

namespace senai_roman_webAPI.Domains
{
    public partial class Tema
    {
        public Tema()
        {
            Projetos = new HashSet<Projeto>();
        }

        public byte IdTema { get; set; }
        public string NomeTema { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
