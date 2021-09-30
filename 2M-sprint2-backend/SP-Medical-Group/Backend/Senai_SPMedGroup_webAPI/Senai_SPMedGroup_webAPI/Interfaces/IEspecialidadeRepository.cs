using Senai_SPMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Lista todas as Especialidades
        /// </summary>
        /// <returns></returns>
        List<Especialidade> ListarTodos();

        /// <summary>
        /// Cadastra uma nova Especialidade
        /// </summary>
        /// <param name="novaEspecialidade"></param>
        void Cadastrar(Especialidade novaEspecialidade);

        /// <summary>
        /// Deleta uma Especialidade
        /// </summary>
        /// <param name="IdEspecialidade"> id da Especialidade que será deletado</param>
        void Deletar(int IdEspecialidade);


        /// <summary>
        /// Busca uma Especialidade pelo seu id
        /// </summary>
        /// <param name="IdEspecialidade">id da Especialidade que será buscado</param>
        /// <returns></returns>
        Especialidade BuscarId(int IdEspecialidade);

        /// <summary>
        /// Atualiza os dados de um IdEspecialidade existente
        /// </summary>
        /// <param name="IdEspecialidade">id da Especialidade e que será atualizada</param>
        /// <param name="especialidadeAtualizada">objeto especialidadeAtualizada com as novas informações</param>
        void Atualizar(int IdEspecialidade, Especialidade especialidadeAtualizada);
    }
}
