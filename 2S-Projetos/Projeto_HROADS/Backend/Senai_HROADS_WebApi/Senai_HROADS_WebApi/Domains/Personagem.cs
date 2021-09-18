using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_HROADS_WebApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public short CapacidadeMaxVida { get; set; }
        public short CapacidadeMaxMana { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
