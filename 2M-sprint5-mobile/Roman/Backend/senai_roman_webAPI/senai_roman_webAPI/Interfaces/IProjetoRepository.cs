using senai_roman_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_roman_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ProjetoRepository
    /// </summary>
    interface IProjetoRepository
    {
        /// <summary>
        /// Listar todas os projetos
        /// </summary>
        /// <returns>Lista com todos os projetos</returns>
        List<Projeto> ListarTodos();

        /// <summary>
        /// Cria um novo projeto
        /// </summary>
        /// <param name="novoProjeto">Objeto com as propriedades a serem cadastradas no projeto novo</param>
        void Cadastrar(Projeto novoProjeto);
    }
}
