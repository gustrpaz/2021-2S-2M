using senai_WishList_webApi.Context;
using senai_WishList_webApi.Domains;
using senai_WishList_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_WishList_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WishListContext Ctx = new WishListContext();

        public void Cadastrar(Usuario NovoUsuario)
        {
            Ctx.Usuarios.Add(NovoUsuario);

            Ctx.SaveChanges();
        }

        public List<Usuario> ListarUsuarios()
        {
            return Ctx.Usuarios.ToList();
        }
    }
}
