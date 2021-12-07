using Senai_SPMedGroup_webAPI.Contexts;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {

        SpMedContext ctx = new SpMedContext();
        public void Atualizar(int IdPaciente, Paciente pacienteAtualizado)
        {
            // Busca um Paciente através do seu id

            Paciente pacienteBuscado = BuscarId(IdPaciente);

            // Verifica se o novo IdPaciente que foi informado existe
            if (pacienteAtualizado.IdPaciente.ToString() != null)
            {
                // Se sim, altera o valor da propriedade Paciente
                pacienteBuscado.IdEndereco = pacienteAtualizado.IdEndereco;
                pacienteBuscado.Nome = pacienteAtualizado.Nome;
                pacienteBuscado.DataNasc = pacienteAtualizado.DataNasc;
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
                pacienteBuscado.Rg = pacienteAtualizado.Rg;
                pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
            }
            // Atualiza o Paciente que foi buscada
            ctx.Pacientes.Update(pacienteBuscado);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }
        

        public Paciente BuscarId(int IdPaciente)
        {
            // Retorna o primeiro Paciente encontrado para o ID informado
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == IdPaciente);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            if (novoPaciente.DataNasc < DateTime.Now)
            {
                // Adiciona um novo Paciente
                ctx.Pacientes.Add(novoPaciente);
            }
           
           
            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int IdPaciente)
        {
            // Busca um Paciente através do seu id
            Paciente pacienteBuscado = BuscarId(IdPaciente);

            // Remove o paciente que foi buscado
            ctx.Pacientes.Remove(pacienteBuscado);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            // Retorna uma lista com todas as informações de Paciente
            return ctx.Pacientes.ToList();
        }
    }
}
