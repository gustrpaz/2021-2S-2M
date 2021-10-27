using senai_WishList_webApi.Context;
using senai_WishList_webApi.Domains;
using senai_WishList_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_WishList_webApi.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        WishListContext Ctx = new WishListContext();

        public void Cadastrar(Desejo NovoDesejo)
        {
            Ctx.Desejos.Add(NovoDesejo);

            Ctx.SaveChanges();
        }

        public List<Desejo> ListarDesejos()
        {
            return Ctx.Desejos.ToList();
        }
    }
}
