using Senai_SPMedGroup_webAPI.Contexts;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using Senai_SPMedGroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedContext ctx = new SpMedContext();
        public void Atualizar(int IdConsulta, Consulta consultaAtualizada)
        {
            // Busca uma consulta através do seu id

            Consulta consultaBuscada = BuscarId(IdConsulta);

            // Verifica se o novo IdConsulta que foi informado existe
            if (consultaAtualizada.IdConsulta.ToString() != null)
            {
                // Se sim, altera o valor da propriedade Clinica, Situação (Agendada, Realizada, Cancelada)
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
                consultaBuscada.DataHora = consultaAtualizada.DataHora;

            }

            // Atualiza a Consulta que foi buscada
            ctx.Consultas.Update(consultaBuscada);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Consulta BuscarId(int IdConsulta)
        {
            // Retorna a primeira Consulta encontrada para o ID informado
            return ctx.Consultas.FirstOrDefault(c => c.IdConsulta == IdConsulta);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            // Adiciona uma nova Consulta
            ctx.Consultas.Add(novaConsulta);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int IdConsulta)
        {
            // Busca uma Consulta através do seu id
            Consulta consultaBuscada = BuscarId(IdConsulta);

            // Remove a consulta que foi buscada
            ctx.Consultas.Remove(consultaBuscada);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }
        public List<Consulta> ListarTodos()
        {
            // Retorna uma lista com todas as informações da Consulta

            //return ctx.Consultas.ToList();

            return ctx.Consultas.Select(x => new Consulta
            {

                IdConsulta = x.IdConsulta,
                IdPaciente = x.IdPaciente,
                IdMedico = x.IdMedico,
                IdSituacao = x.IdSituacao,
                Descricao = x.Descricao,
                DataHora = x.DataHora,

                IdSituacaoNavigation = new Situacao()
                {
                    Situacao1 = x.IdSituacaoNavigation.Situacao1
                },

                IdMedicoNavigation = new Medico()
                {
                    Crm = x.IdMedicoNavigation.Crm,
                    NomeMedico = x.IdMedicoNavigation.NomeMedico,

                    IdUsuarioNavigation = new Usuario()
                    {
                        Email = x.IdMedicoNavigation.IdUsuarioNavigation.Email
                    },

                    IdEspecialidadeNavigation = new Especialidade()
                    {
                        Especialidades = x.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidades
                    },

                    IdClinicaNavigation = new Clinica()
                    {
                        NomeClinica = x.IdMedicoNavigation.IdClinicaNavigation.NomeClinica
                    }
                },

                IdPacienteNavigation = new Paciente()
                {
                    Nome = x.IdPacienteNavigation.Nome
                },
            }).ToList();
        }

        public List<Consulta> ListarMinhas(int IdUsuario)
        {
            //return ctx.Consultas.Select(c => c.IdPaciente == IdPaciente).ToList();
            Paciente paciente = ctx.Pacientes.FirstOrDefault(u => u.IdUsuario == IdUsuario);
            int IdPaciente = paciente.IdPaciente;

            return ctx.Consultas
                .Where(x => x.IdPaciente == IdPaciente)
                .Select(x => new Consulta
                {
                    IdPaciente = x.IdPaciente,
                    IdMedico = x.IdMedico,
                    IdSituacao = x.IdSituacao,
                    Descricao = x.Descricao,

                    IdSituacaoNavigation = new Situacao()
                    {
                        Situacao1 = x.IdSituacaoNavigation.Situacao1
                    },

                    IdPacienteNavigation = new Paciente()
                    {
                        Nome = x.IdPacienteNavigation.Nome
                    },


                    IdMedicoNavigation = new Medico()
                    {
                        Crm = x.IdMedicoNavigation.Crm,
                        NomeMedico = x.IdMedicoNavigation.NomeMedico,

                        IdClinicaNavigation = new Clinica()
                        {
                            NomeClinica = x.IdMedicoNavigation.IdClinicaNavigation.NomeClinica
                        },

                        IdEspecialidadeNavigation = new Especialidade()
                        {
                            Especialidades = x.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidades
                        },


                    },
                    DataHora = x.DataHora

                }).ToList();

        }


        /// <summary>
        /// Método para Listar as consultas que algum médico terá
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public List<Consulta> ListarMinhasMed(int IdUsuario)
        {
            //return ctx.Consultas.Select(c => c.IdPaciente == IdPaciente).ToList();
            Medico medico = ctx.Medicos.FirstOrDefault(u => u.IdUsuario == IdUsuario);
            int IdMedico = medico.IdMedico;

            return ctx.Consultas
                .Where(x => x.IdMedico == IdMedico)
                .Select(x => new Consulta
                {
                    IdConsulta = x.IdConsulta,
                    IdPaciente = x.IdPaciente,
                    IdMedico = x.IdMedico,
                    IdSituacao = x.IdSituacao,
                    Descricao = x.Descricao,
                    DataHora = x.DataHora,

                    IdSituacaoNavigation = new Situacao()
                    {
                        Situacao1 = x.IdSituacaoNavigation.Situacao1
                    },

                    IdMedicoNavigation = new Medico()
                    {
                        Crm = x.IdMedicoNavigation.Crm,
                        NomeMedico = x.IdMedicoNavigation.NomeMedico,

                        IdUsuarioNavigation = new Usuario()
                        {
                            Email = x.IdMedicoNavigation.IdUsuarioNavigation.Email
                        },

                        IdEspecialidadeNavigation = new Especialidade()
                        {
                            Especialidades = x.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidades
                        },

                        IdClinicaNavigation = new Clinica()
                        {
                            NomeClinica = x.IdMedicoNavigation.IdClinicaNavigation.NomeClinica
                        }
                    },

                    IdPacienteNavigation = new Paciente()
                    {
                        Nome = x.IdPacienteNavigation.Nome
                    },
                }).ToList();

        }



        /// <summary>
        /// Método para o médico alterar a situação da consulta de algum paciente
        /// </summary>
        /// <param name="IdConsulta"></param>
        /// <param name="consultaAtualizada"></param>
        public void SituacaoConsulta(int IdConsulta, Consulta consultaAtualizada)
        {
            // Busca uma consulta através do seu id
            Consulta consultaBuscada = BuscarId(IdConsulta);

            // Verifica se o novo IdConsulta que foi informado existe
            if (consultaAtualizada.IdConsulta.ToString() != null)
            {
                // Se sim, altera o valor da propriedade Clinica, Situação (Agendada, Realizada, Cancelada)              
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
            }
            // Atualiza a Consulta que foi buscada
            ctx.Consultas.Update(consultaBuscada);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }


        public void AlterarDescricao(string descricao, int IdConsulta)
        {
            Consulta consultaBuscado = BuscarId(IdConsulta);

            if (descricao != null)
            {
                consultaBuscado.Descricao = descricao;

                ctx.Consultas.Update(consultaBuscado);

                ctx.SaveChanges();
            };

        }


        public List<Consulta> ListarMinhasMobile(int IdUsuario)
        {
            return ctx.Consultas
                .Where(x => x.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario == IdUsuario || x.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario == IdUsuario)
                .Select(x => new Consulta
            {
                    IdConsulta = x.IdConsulta,
                IdPaciente = x.IdPaciente,
                IdMedico = x.IdMedico,
                IdSituacao = x.IdSituacao,
                Descricao = x.Descricao,

                IdSituacaoNavigation = new Situacao()
                {
                    Situacao1 = x.IdSituacaoNavigation.Situacao1
                },

                IdPacienteNavigation = new Paciente()
                {
                    Nome = x.IdPacienteNavigation.Nome
                },


                IdMedicoNavigation = new Medico()
                {
                    Crm = x.IdMedicoNavigation.Crm,
                    NomeMedico = x.IdMedicoNavigation.NomeMedico,

                    IdClinicaNavigation = new Clinica()
                    {
                        NomeClinica = x.IdMedicoNavigation.IdClinicaNavigation.NomeClinica
                    },

                    IdEspecialidadeNavigation = new Especialidade()
                    {
                        Especialidades = x.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidades
                    },


                },
                DataHora = x.DataHora

            }).ToList();//.Where(x => x.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario == IdUsuario || x.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario == IdUsuario).ToList();

        }
        }
    }
