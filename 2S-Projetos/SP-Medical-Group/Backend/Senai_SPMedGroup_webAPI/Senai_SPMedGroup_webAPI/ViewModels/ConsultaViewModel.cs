using Senai_SPMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.ViewModels
{
    public class ConsultaViewModel
    {
       
        public int IdSituacao { get; set; }
     
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "É necessário que seja passado um idMedico da consulta!")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "A data e hora são obrigatórias!")]
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }

 
    }
}
