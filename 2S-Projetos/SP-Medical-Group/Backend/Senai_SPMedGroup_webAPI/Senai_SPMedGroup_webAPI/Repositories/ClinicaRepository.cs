using Senai_SPMedGroup_webAPI.Contexts;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {

        SpMedContext ctx = new SpMedContext();

        public void Atualizar(int IdClinica, Clinica clinicaAtualizado)
        {
            // Busca um Clinica através do seu id

            Clinica clinicaBuscada = BuscarId(IdClinica);

            // Verifica se o novo NomeClinica que foi informado existe
            if (clinicaAtualizado.NomeClinica != null)
            {
                // Se sim, altera o valor da propriedade Clinica
                clinicaBuscada.NomeClinica = clinicaAtualizado.NomeClinica;
                clinicaBuscada.IdEndereco = clinicaAtualizado.IdEndereco;
                clinicaBuscada.HoraInicio = clinicaAtualizado.HoraInicio;
                clinicaBuscada.HoraFim = clinicaAtualizado.HoraFim;
                clinicaBuscada.Cnpj = clinicaAtualizado.Cnpj;
                clinicaBuscada.RazaoSocial = clinicaAtualizado.RazaoSocial;
            }

            // Atualiza a Clinica que foi buscado
            ctx.Clinicas.Update(clinicaBuscada);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Clinica BuscarId(int IdClinica)
        {
            // Retorna a primeira Clinica encontrada para o ID informado
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == IdClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            // Adiciona uma nova Clínica
            ctx.Clinicas.Add(novaClinica);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int IdClinica)
        {
            // Busca uma Clínica através do seu id
            Clinica clinicaBuscada = BuscarId(IdClinica);

            // Remove a clínica que foi buscada
            ctx.Clinicas.Remove(clinicaBuscada);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            // Retorna uma lista com todas as informações das Clínicas
            return ctx.Clinicas.Select(x => new Clinica
            {
                IdClinica = x.IdClinica,
                IdEndereco = x.IdEndereco,
                HoraInicio = x.HoraInicio,
                HoraFim = x.HoraFim,
                Cnpj = x.Cnpj,
                NomeClinica = x.NomeClinica,
                RazaoSocial = x.RazaoSocial,

                IdEnderecoNavigation = new Endereco()
                {
                    Logadouro = x.IdEnderecoNavigation.Logadouro,
                    Numero = x.IdEnderecoNavigation.Numero,
                    Bairro = x.IdEnderecoNavigation.Bairro,
                    Municipio = x.IdEnderecoNavigation.Municipio,
                    Estado = x.IdEnderecoNavigation.Estado,
                    Cep = x.IdEnderecoNavigation.Cep,
                },
            }).ToList();        
            
        } 
        
    }
}
