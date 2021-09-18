using Senai_HROADS_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsávelo pelo UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns></returns>
        List<Usuario> ListarTodos();


        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario"></param>
        void Cadastrar(Usuario novoUsuario);


        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="IdUsuario">id do usuario que será deletado</param>
        void Deletar(int IdUsuario);


        /// <summary>
        /// Busca um usuário pelo seu id
        /// </summary>
        /// <param name="IdUsuario">id do usuário que será buscado</param>
        /// <returns></returns>
        Usuario BuscarId(int IdUsuario);

        /// <summary>
        /// Atualiza os dados de um usuario existente
        /// </summary>
        /// <param name="IdUsuario">id do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">objeto usuarioAtualizado com as novas informações</param>
        void Atualizar(int IdUsuario, Usuario usuarioAtualizado);

        Usuario Login(string email, string senha);
    }
}
