using Senai_HROADS_WebApi.Contexts;
using Senai_HROADS_WebApi.Domains;
using Senai_HROADS_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Repositories
{

    public class TipoHabilidadeRepository : ITiposHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idTipos, TiposHabilidade TiposHabilidadeAtualizado)
        {
            TiposHabilidade tipoBuscado = ctx.TiposHabilidades.Find(idTipos);

            if (TiposHabilidadeAtualizado != null)
            {
                tipoBuscado.NomeTipo = TiposHabilidadeAtualizado.NomeTipo;
            }

            ctx.TiposHabilidades.Update(tipoBuscado);

            ctx.SaveChanges();


        }

        public TiposHabilidade BuscarId(int idTipos)
        {
            //ERRO
            return ctx.TiposHabilidades.FirstOrDefault(th => th.IdTipos == idTipos);
        }

        public void Cadastrar(TiposHabilidade novoTiposHabilidade)
        {
            ctx.TiposHabilidades.Add(novoTiposHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipos)
        {
            //ERRO
            TiposHabilidade tipoBuscado = BuscarId(idTipos);

            ctx.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

        public List<TiposHabilidade> ListarTodos()
        {
            return ctx.TiposHabilidades.ToList();
        }
    }
}
