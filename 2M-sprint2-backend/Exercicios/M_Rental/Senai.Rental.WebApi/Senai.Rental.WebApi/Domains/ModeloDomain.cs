using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ModeloDomain
    {

        /// <summary>
        /// Classe que representa a entidade (tabela) Modelo
        /// </summary>

        public int idModelo { get; set; }

        public int idMarca { get; set; }

        public string nomeModelo { get; set; }

    }
}
