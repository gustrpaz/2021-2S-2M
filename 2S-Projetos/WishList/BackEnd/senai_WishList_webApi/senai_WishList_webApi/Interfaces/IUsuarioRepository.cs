using senai_WishList_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_WishList_webApi.Interfaces
{
    interface IUsuarioRepository 
    {
        void Cadastrar(Usuario NovoUsuario);

        List<Usuario> ListarUsuarios();

    }
}
