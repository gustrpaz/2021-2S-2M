using Senai_SPMedGroup_webAPI.Contexts;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedContext ctx = new SpMedContext();
        public void Atualizar(int IdMedico, Medico medicoAtualizado)
        {
            // Busca um Médico através do seu id

            Medico medicoBuscado = BuscarId(IdMedico);

            // Verifica se o novo NomeMedico que foi informado existe
            if (medicoAtualizado.NomeMedico != null)
            {
                // Se sim, altera o valor da propriedade Médico
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
                medicoBuscado.Crm = medicoAtualizado.Crm;
                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;
                medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;
            }

            // Atualiza o Médico que foi buscado
            ctx.Medicos.Update(medicoBuscado);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Medico BuscarId(int IdMedico)
        {
            // Retorna o primeiro Médico encontrado para o ID informado
            return ctx.Medicos.FirstOrDefault(t => t.IdMedico == IdMedico);
        }

        public void Cadastrar(Medico novoMedico)
        {
            // Adiciona um novo Médico
            ctx.Medicos.Add(novoMedico);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int IdMedico)
        {
            // Busca um Médico através do seu id
            Medico medicoBuscado = BuscarId(IdMedico);

            // Remove um médico que foi buscado
            ctx.Medicos.Remove(medicoBuscado);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            // Retorna uma lista com todas as informações dos Médicos
           
            return ctx.Medicos.Select(m => new Medico
            {
                IdMedico= m.IdMedico,
                IdUsuario = m.IdUsuario,
                IdClinica = m.IdClinica,
                IdEspecialidade = m.IdEspecialidade,
                NomeMedico = m.NomeMedico,
                Crm = m.Crm,
                IdEspecialidadeNavigation = new Especialidade()
                {
                    Especialidades = m.IdEspecialidadeNavigation.Especialidades,
                },
                IdClinicaNavigation = new Clinica()
                {
                    NomeClinica = m.IdClinicaNavigation.NomeClinica,             
                },
            }).ToList();
        }
     
    }
}
