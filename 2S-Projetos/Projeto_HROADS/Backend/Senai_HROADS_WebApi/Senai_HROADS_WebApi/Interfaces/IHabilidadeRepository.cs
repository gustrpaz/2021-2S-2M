using Senai_HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsávelo pelo HabilidadeRepository
    /// </summary>
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns></returns>
        List<Habilidade> ListarTodos();

        /// <summary>
        /// Cadastra uma nova Habilidade
        /// </summary>
        /// <param name="novaHabilidade"></param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Deleta uma Habilidade
        /// </summary>
        /// <param name="idHabilidade"> id da Habilidade que será deletado</param>
        void Deletar(int idHabilidade);


        /// <summary>
        /// Busca uma Habilidade pelo seu id
        /// </summary>
        /// <param name="idHabilidade">id do idHabilidade que será buscado</param>
        /// <returns></returns>
        Habilidade BuscarId(int idHabilidade);

        /// <summary>
        /// Atualiza os dados de um idHabilidade existente
        /// </summary>
        /// <param name="idHabilidade">id do Habilidade e que será atualizado</param>
        /// <param name="HabilidadeAtualizado">objeto idHabilidadeAtualizado com as novas informações</param>
        void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizado);
    }
}
