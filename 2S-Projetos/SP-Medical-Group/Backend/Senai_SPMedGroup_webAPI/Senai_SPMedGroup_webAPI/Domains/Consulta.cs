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

        [Required(ErrorMessage = "É necessário que seja passado um idMedico da consulta!")]
        public int? IdMedico { get; set; }
        public int? IdSituacao { get; set; }

        [Required(ErrorMessage = "A data e hora são obrigatórias!")]
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
