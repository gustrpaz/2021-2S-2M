using Senai_HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsávelo pelo ClasseHablididadeRepository
    /// </summary>
    interface IClasseHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os Classe_Habilidade
        /// </summary>
        /// <returns></returns>
        List<ClasseHabilidade> ListarTodos();

        /// <summary>
        /// Cadastra uma nova Classe_Habilidade
        /// </summary>
        /// <param name="novaClasseHabilidade"></param>
        void Cadastrar(ClasseHabilidade novaClasseHabilidade);

        /// <summary>
        /// Deleta uma Classe_Habilidade
        /// </summary>
        /// <param name="Id"> id da Classe_Habilidade que será deletado</param>
        void Deletar(int Id);


        /// <summary>
        /// Busca uma Classe_Habilidade pelo seu id
        /// </summary>
        /// <param name="Id">id do id Classe Habilidade que será buscado</param>
        /// <returns></returns>
        ClasseHabilidade BuscarId(int Id);

        /// <summary>
        /// Atualiza os dados de um Id
        /// </summary>
        /// <param name="Id">id do Classe_Habilidade e que será atualizado</param>
        /// <param name="classeHabilidadeAtualizado">objeto id Classe_Habilidade o com as novas informações</param>
        void Atualizar(int Id, ClasseHabilidade classeHabilidadeAtualizado);
    }
}
