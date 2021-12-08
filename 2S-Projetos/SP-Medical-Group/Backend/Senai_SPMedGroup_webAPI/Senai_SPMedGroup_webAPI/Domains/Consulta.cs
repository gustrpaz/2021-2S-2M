using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMedGroup_webAPI.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }

     
        public int? IdMedico { get; set; }
        public int? IdSituacao { get; set; }

        
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
