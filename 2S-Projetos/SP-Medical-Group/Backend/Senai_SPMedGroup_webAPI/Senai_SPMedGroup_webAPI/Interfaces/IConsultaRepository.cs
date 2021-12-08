using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todas as Cosultas
        /// </summary>
        /// <returns></returns>
        List<Consulta> ListarTodos();

        /// <summary>
        /// Lista as consultas de um determinado paciente
        /// </summary>
        /// <returns></returns>
        List<Consulta> ListarMinhas(int IdPaciente);


        /// <summary>
        /// Lista apenas as consultas de um determinado médico
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        List<Consulta> ListarMinhasMed(int IdUsuario);

        /// <summary>
        /// Cadastra uma nova Consulta
        /// </summary>
        /// <param name="novaConsulta"></param>
        void Cadastrar(Consulta novaConsulta);

        /// <summary>
        /// Deleta uma Consulta
        /// </summary>
        /// <param name="IdConsulta"> id da Consulta que será deletado</param>
        void Deletar(int IdConsulta);


        /// <summary>
        /// Busca uma Consulta pelo seu id
        /// </summary>
        /// <param name="IdConsulta">id da Consulta que será buscado</param>
        /// <returns></returns>
        Consulta BuscarId(int IdConsulta);

        /// <summary>
        /// Atualiza os dados de um IdConsulta existente
        /// </summary>
        /// <param name="IdConsulta">id da Consulta e que será atualizada</param>
        /// <param name="consultaAtualizada">objeto consultaAtualizada com as novas informações</param>
        void Atualizar(int IdConsulta, Consulta consultaAtualizada);

        /// <summary>
        /// Atualiza o estado da consulta, podendo mudar apenas o Id situação
        /// </summary>
        /// <param name="IdConsulta"></param>
        /// <param name="consultaAtualizada"></param>
        void SituacaoConsulta(int IdConsulta, Consulta consultaAtualizada);

        void AlterarDescricao(string descricao, int IdUsuario);


        List<Consulta>ListarMinhasMobile(int IdUsuario);    
    }
}
