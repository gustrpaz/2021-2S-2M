using Senai_SPMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista todas os Pacientes
        /// </summary>
        /// <returns></returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Cadastra um novo Paciente
        /// </summary>
        /// <param name="novoPaciente"></param>
        void Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Deleta um Paciente
        /// </summary>
        /// <param name="IdPaciente"> id do Paciente que será deletado</param>
        void Deletar(int IdPaciente);


        /// <summary>
        /// Busca uma Paciente pelo seu id
        /// </summary>
        /// <param name="IdPaciente">id do Paciente que será buscado</param>
        /// <returns></returns>
        Paciente BuscarId(int IdPaciente);

        /// <summary>
        /// Atualiza os dados de um IdPaciente existente
        /// </summary>
        /// <param name="IdPaciente">id da Paciente e que será atualizada</param>
        /// <param name="pacienteAtualizado">objeto pacienteAtualizado com as novas informações</param>
        void Atualizar(int IdPaciente, Paciente pacienteAtualizado);
    }
}
