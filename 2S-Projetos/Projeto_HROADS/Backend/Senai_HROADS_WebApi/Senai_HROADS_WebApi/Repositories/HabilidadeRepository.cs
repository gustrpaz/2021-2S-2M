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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizado)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(idHabilidade);

            if (HabilidadeAtualizado.NomeHabilidade != null)
            {
                habilidadeBuscada.IdTipos = HabilidadeAtualizado.IdTipos;
                habilidadeBuscada.NomeHabilidade = HabilidadeAtualizado.NomeHabilidade;

            }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();

        }

        public Habilidade BuscarId(int IdHabilidade)
        {
           return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == IdHabilidade);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            Habilidade habilidaeeBuscada = BuscarId(idHabilidade);

            ctx.Remove(habilidaeeBuscada);

            ctx.SaveChanges();
        }

        public List<Habilidade> ListarTodos()
        {
            //IDTIPOHABILIDADE não aparece o nome??
            return ctx.Habilidades.Include(h => h.IdTiposNavigation).ToList();
        }
    }
}
