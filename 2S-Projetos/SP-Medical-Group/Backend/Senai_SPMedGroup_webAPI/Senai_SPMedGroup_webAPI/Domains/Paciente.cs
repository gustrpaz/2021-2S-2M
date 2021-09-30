using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SPMedGroup_webAPI.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEndereco { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
