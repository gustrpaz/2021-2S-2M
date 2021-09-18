using Senai_HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsávelo pelo TiposHabilidadeRepository
    /// </summary>
    interface ITiposHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os TiposHabilidade
        /// </summary>
        /// <returns></returns>
        List<TiposHabilidade> ListarTodos();

        /// <summary>
        /// Cadastra um novo novoTiposHabilidade
        /// </summary>
        /// <param name="novoTiposHabilidade"></param>
        void Cadastrar(TiposHabilidade novoTiposHabilidade);

        /// <summary>
        /// Deleta um Tipo de Habilidade
        /// </summary>
        /// <param name="idTipos"> id do Tipo Habilidade que será deletado</param>
        void Deletar(int idTipos);


        /// <summary>
        /// Busca um idTipos pelo seu id
        /// </summary>
        /// <param name="idTipos">id do idTipos que será buscado</param>
        /// <returns></returns>
        TiposHabilidade BuscarId(int idTipos);

        /// <summary>
        /// Atualiza os dados de um idTipos existente
        /// </summary>
        /// <param name="idTipos">id do TipoHabilidade que será atualizado</param>
        /// <param name="TiposHabilidadeAtualizado">objeto idTiposAtualizado com as novas informações</param>
        void Atualizar(int idTipos, TiposHabilidade TiposHabilidadeAtualizado);

    }
}
