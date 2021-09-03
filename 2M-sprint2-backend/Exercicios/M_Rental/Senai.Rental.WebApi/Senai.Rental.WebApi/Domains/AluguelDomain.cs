using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomain
    {
        /// <summary>
        /// Classe que representa a entidade (tabela) Aluguel
        /// </summary>

        public int idAluguel { get; set; }

        public int idVeiculo { get; set; }

        public int idCliente { get; set; }
        public ClienteDomain cliente { get; set; }

        public VeiculoDomain veiculo { get; set; }

        public ModeloDomain modelo { get; set; }


        public DateTime DataDevol { get; set; }

        public DateTime DataRetirada { get; set; }
    }
}
