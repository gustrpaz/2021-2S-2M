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
    public class UsuarioRepository : IUsuarioRepository
    {

        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();


        public void Atualizar(int IdUsuario, Usuario usuarioAtualizado)
        {
            // Busca um usuario através do seu id
          
            Usuario usuarioBuscado = BuscarId(IdUsuario);

            // Verifica se o novo nome do usuário foi informado
            if (usuarioAtualizado.Email != null || usuarioAtualizado.Senha != null || usuarioAtualizado.IdTipoUsuario != null)
            {
                // Se sim, altera o valor da propriedade 
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

            }

            // Atualiza o Usuario que foi buscado
            ctx.Usuarios.Update(usuarioBuscado);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Usuario BuscarId(int IdUsuario)
        {
            // Retorna o primeiro Usuário encontrado para o ID informado
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == IdUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona um novo Usuário
            ctx.Usuarios.Add(novoUsuario);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int IdUsuario)
        {
            // Busca um Usuário através do seu id
            Usuario usuarioBuscado = BuscarId(IdUsuario);

            // Remove o usuário que foi buscado
            ctx.Usuarios.Remove(usuarioBuscado);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            // Retorna uma lista com todas as informações dos Usuários
            //return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();

            return ctx.Usuarios.Select(x => new Usuario
             {
                 IdTipoUsuarioNavigation = x.IdTipoUsuarioNavigation,
                 IdUsuario= x.IdUsuario,
                 Email = x.Email,
             }).ToList();
        }

        public Usuario Login (string email, string senha) 
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }

    }
}
