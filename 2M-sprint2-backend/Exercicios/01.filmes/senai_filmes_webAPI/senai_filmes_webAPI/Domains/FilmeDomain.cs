using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    public class FilmeDomain
    {
        /// <summary>
        /// Classe que representa a entidade (tabela) Filme
        /// </summary>
      
            public int idFilme { get; set; }

            public int idGenero { get; set; }

            public string tituloFilme { get; set; }
        }
    }

