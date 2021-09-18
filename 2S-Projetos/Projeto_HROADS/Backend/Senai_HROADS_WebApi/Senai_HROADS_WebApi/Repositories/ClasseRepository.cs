using Senai_HROADS_WebApi.Contexts;
using Senai_HROADS_WebApi.Domains;
using Senai_HROADS_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int IdClasse, Classe classeAtualizado)
        {
            // Busca uma classe através do seu id
       
            Classe classeBuscado = BuscarId(IdClasse);

            // Verifica se o novo nome da classe que foi informado
            if (classeAtualizado.NomeClasse != null)
            {
                // Se sim, altera o valor da propriedade NomeCalsse
                classeBuscado.NomeClasse = classeAtualizado.NomeClasse;
            }

            // Atualiza a Classe que foi buscado
            ctx.Classes.Update(classeBuscado);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Classe BuscarId(int IdClasse)
        {
            // Retorna a primeira Classe encontrado para o ID informado
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == IdClasse);
        }

        public void Cadastrar(Classe novaClasse)
        {
            // Adiciona uma nova Classe
            ctx.Classes.Add(novaClasse);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int IdClasse)
        {
            // Busca uma classe através do seu id
            Classe classeBuscado = BuscarId(IdClasse);

            // Remove a classe que foi buscada
            ctx.Classes.Remove(classeBuscado);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Classe> ListarTodos()
        {
            // Retorna uma lista com todas as informações das Classes
            return ctx.Classes.ToList();
        }

        Classe IClasseRepository.BuscarId(int IdClasse)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == IdClasse);
        }
    }
}
