using Microsoft.EntityFrameworkCore;
using Senai_HROADS_WebApi.Contexts;
using Senai_HROADS_WebApi.Domains;
using Senai_HROADS_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int IdPersonagem, Personagem PersonagemAtualizado)
        {
            Personagem personagemBuscado = ctx.Personagems.Find(IdPersonagem);

            if (PersonagemAtualizado != null)
            {
                ///Coloca o id TipoHabilidade
                
                personagemBuscado.IdClasse = PersonagemAtualizado.IdClasse;
                personagemBuscado.NomePersonagem = PersonagemAtualizado.NomePersonagem;
                personagemBuscado.CapacidadeMaxVida = PersonagemAtualizado.CapacidadeMaxVida;
                personagemBuscado.CapacidadeMaxMana = PersonagemAtualizado.CapacidadeMaxMana;
                personagemBuscado.DataCriacao = PersonagemAtualizado.DataCriacao;
                personagemBuscado.DataAtualizacao = PersonagemAtualizado.DataAtualizacao;

    }

            ctx.Personagems.Update(personagemBuscado);

            ctx.SaveChanges();

        }

        public Personagem BuscarId(int IdPersonagem)
        {
            return ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == IdPersonagem);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            ctx.Personagems.Add(novoPersonagem);

            ctx.SaveChanges();
        }

        public void Deletar(int IdPersonagem)
        {
            Personagem personagemBuscada = BuscarId(IdPersonagem);

            ctx.Remove(personagemBuscada);

            ctx.SaveChanges();
        }

        public List<Personagem> ListarTodos()
        {
            return ctx.Personagems.Include(p => p.IdClasseNavigation).ToList();
        }

        Personagem IPersonagemRepository.BuscarId(int IdPersonagem)
        {
            return ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == IdPersonagem);
        }
    }
}
