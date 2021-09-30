using Senai_SPMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Interfaces
{
    interface ISituacaoRepository
    {
        /// <summary>
        /// Lista todas as Situações
        /// </summary>
        /// <returns></returns>
        List<Situacao> ListarTodos();


        /// <summary>
        /// Buscar algum item por Id
        /// </summary>
        /// <param name="IdSituacao"></param>
        /// <returns></returns>
        Situacao BuscarId(int IdSituacao);
      
        /// <summary>
        /// Atualiza os dados de um IdSituacao existente
        /// </summary>
        /// <param name="IdSituacao">id da Situacao e que será atualizada</param>
        /// <param name="situacaoAtualizada">objeto situacaoAtualizada com as novas informações</param>
        void Atualizar(int IdSituacao, Situacao situacaoAtualizada);
    }

}
