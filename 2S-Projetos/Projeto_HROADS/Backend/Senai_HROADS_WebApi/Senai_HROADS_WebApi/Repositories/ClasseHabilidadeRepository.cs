using Senai_HROADS_WebApi.Contexts;
using Senai_HROADS_WebApi.Domains;
using Senai_HROADS_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();


        public void Atualizar(int Id, ClasseHabilidade classeHabilidadeAtualizado)
        {
            // Busca uma Classe Habilidade através do seu id

            ClasseHabilidade classeHabilidadeBuscadoBuscado = ctx.ClasseHabilidades.Find(Id);
            // Outra forma
            ClasseHabilidade classeHabilidadeBuscado = BuscarId(Id);

            // Verifica se o novo id Classe Habilidade foi informado
            if (classeHabilidadeAtualizado.Id.ToString() != null)
            {
                // Se sim, altera o valor da propriedade Id
                classeHabilidadeBuscado.IdClasse = classeHabilidadeAtualizado.IdClasse;
                classeHabilidadeBuscado.IdHabilidade = classeHabilidadeAtualizado.IdHabilidade;
            }

            // Atualiza a Classe habilidade que foi buscado
            ctx.ClasseHabilidades.Update(classeHabilidadeBuscado);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public ClasseHabilidade BuscarId(int Id)
        {
            // Retorna o primeiro classe habilidade encontrado para o ID informado
            return ctx.ClasseHabilidades.FirstOrDefault(e => e.Id == Id);
        }

        public void Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            // Adiciona uma nova Classe Habilidade
            ctx.ClasseHabilidades.Add(novaClasseHabilidade);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            // Busca um Classe Habilidade através do seu id
            ClasseHabilidade ClassesHabilidadeBuscado = BuscarId(Id);

            // Remove o Classes Habilidade que foi buscado
            ctx.ClasseHabilidades.Remove(ClassesHabilidadeBuscado);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<ClasseHabilidade> ListarTodos()
        {
            // Retorna uma lista com todas as informações de ClasseHabilidades
            return ctx.ClasseHabilidades.ToList();
        }
    }
}
