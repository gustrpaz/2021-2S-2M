using Senai_SPMedGroup_webAPI.Contexts;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SpMedContext ctx = new SpMedContext();
        public void Atualizar(int IdEspecialidade, Especialidade especialidadeAtualizada)
        {
            // Busca uma Especialidade através do seu id

            Especialidade especialidadeBuscada = BuscarId(IdEspecialidade);

            // Verifica se a nova especialidade que foi informado existe
            if (especialidadeAtualizada.Especialidades != null)
            {
                // Se sim, altera o valor da propriedade Especialidade
                especialidadeBuscada.Especialidades = especialidadeAtualizada.Especialidades;
              
            }
            // Atualiza a Especialidade que foi buscada
            ctx.Especialidades.Update(especialidadeBuscada);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Especialidade BuscarId(int IdEspecialidade)
        {
            // Retorna a primeira Especialidade encontrada para o ID informado
            return ctx.Especialidades.FirstOrDefault(e => e.IdEpecialidade == IdEspecialidade);
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            // Adiciona uma nova Especialidade
            ctx.Especialidades.Add(novaEspecialidade);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int IdEspecialidade)
        {
            // Busca uma Especialidade através do seu id
            Especialidade especialidadeBuscada = BuscarId(IdEspecialidade);

            // Remove a especialidade que foi buscada
            ctx.Especialidades.Remove(especialidadeBuscada);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges(); 
        }

        public List<Especialidade> ListarTodos()
        {
            // Retorna uma lista com todas as informações das Especialidade
            return ctx.Especialidades.ToList();
        }
    }
}
