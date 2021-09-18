using Senai_HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsávelo pelo ClasseRepository
    /// </summary>
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todos os Classe
        /// </summary>
        /// <returns></returns>
        List<Classe> ListarTodos();

        /// <summary>
        /// Cadastra uma nova Classe
        /// </summary>
        /// <param name="classe"></param>
        void Cadastrar(Classe classe);

        /// <summary>
        /// Deleta uma Classe
        /// </summary>
        /// <param name="IdClasse"> id da Classe que será deletado</param>
        void Deletar(int IdClasse);


        /// <summary>
        /// Busca uma Classe pelo seu id
        /// </summary>
        /// <param name="IdClasse">id do idClasse que será buscado</param>
        /// <returns></returns>
        Classe BuscarId(int IdClasse);

        /// <summary>
        /// Atualiza os dados de um idClasse existente
        /// </summary>
        /// <param name="IdClasse">id do Classe e que será atualizado</param>
        /// <param name="classeAtualizado">objeto idClasseAtualizado com as novas informações</param>
        void Atualizar(int IdClasse, Classe classeAtualizado);
    }
}
