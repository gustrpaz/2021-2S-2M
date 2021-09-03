using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ClienteDomain
    {
        /// <summary>
        /// Classe que representa a entidade (tabela) Cliente
        /// </summary>

        public int idCliente { get; set; }

        public string nomeCliente { get; set; }

        public string sobrenome { get; set; }

    }
}
