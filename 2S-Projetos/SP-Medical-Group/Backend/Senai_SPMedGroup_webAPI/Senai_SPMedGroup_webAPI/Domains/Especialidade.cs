using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SPMedGroup_webAPI.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdEpecialidade { get; set; }
        public string Especialidades { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
