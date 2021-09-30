using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SPMedGroup_webAPI.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }
        public int? IdEndereco { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }
        public string Cnpj { get; set; }
        public string NomeClinica { get; set; }
        public string RazaoSocial { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
