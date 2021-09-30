using Senai_SPMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todos as Clinica
        /// </summary>
        /// <returns></returns>
        List<Clinica> ListarTodos();

        /// <summary>
        /// Cadastra uma nova Clinica
        /// </summary>
        /// <param name="novaClinica"></param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Deleta uma Clinica
        /// </summary>
        /// <param name="IdClinica"> id da Clinica que será deletada</param>
        void Deletar(int IdClinica);


        /// <summary>
        /// Busca uma Clinica pelo seu id
        /// </summary>
        /// <param name="IdClinica">id do IdClinica que será buscado</param>
        /// <returns></returns>
        Clinica BuscarId(int IdClinica);

        /// <summary>
        /// Atualiza os dados de um IdClinica existente
        /// </summary>
        /// <param name="IdClinica">Id da Clinica e que será atualizado</param>
        /// <param name="clinicaAtualizado">objeto clinicaAtualizado com as novas informações</param>
        void Atualizar(int IdClinica, Clinica clinicaAtualizado);
    }
}
