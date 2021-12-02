using senai_roman_webAPI.Contexts;
using senai_roman_webAPI.Domains;
using senai_roman_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_roman_webAPI.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        RomanContext ctx = new RomanContext();

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        public List<Projeto> ListarTodos()
        {
            return ctx.Projetos.Select(x => new Projeto
            {

                IdProjeto = x.IdProjeto,
                IdTema = x.IdTema,
                NomeProjeto = x.NomeProjeto,
                DescricaoProjeto = x.DescricaoProjeto,

                IdTemaNavigation = new Tema()
                {
                    NomeTema = x.IdTemaNavigation.NomeTema
                },


            }).ToList();
        }
    }
}
