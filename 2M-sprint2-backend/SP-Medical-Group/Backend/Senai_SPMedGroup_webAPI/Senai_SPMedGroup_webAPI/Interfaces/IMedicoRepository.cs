using Senai_SPMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todos os médicos
        /// </summary>
        /// <returns></returns>
        List<Medico> ListarTodos();

        /// <summary>
        /// Cadastra um novo Médico
        /// </summary>
        /// <param name="novoMedico"></param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Deleta um Médico
        /// </summary>
        /// <param name="IdMedico"> id do Médico que será deletada</param>
        void Deletar(int IdMedico);


        /// <summary>
        /// Busca um Médico pelo seu id
        /// </summary>
        /// <param name="IdMedico">id do IdMedico que será buscado</param>
        /// <returns></returns>
        Medico BuscarId(int IdMedico);

        /// <summary>
        /// Atualiza os dados de um IdMedico existente
        /// </summary>
        /// <param name="IdMedico">Id do Medico e que será atualizado</param>
        /// <param name="medicoAtualizado">objeto medicoAtualizado com as novas informações</param>
        void Atualizar(int IdMedico, Medico medicoAtualizado);

       
    }
}
