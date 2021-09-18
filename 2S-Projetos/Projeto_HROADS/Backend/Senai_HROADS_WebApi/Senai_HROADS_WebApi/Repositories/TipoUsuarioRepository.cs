using Senai_HROADS_WebApi.Contexts;
using Senai_HROADS_WebApi.Domains;
using Senai_HROADS_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_HROADS_WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int IdTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            // Busca um TipoUsuario através do seu id
           
            TipoUsuario tipoUsuarioBuscado = BuscarId(IdTipoUsuario);

            // Verifica se o novo nome do tipo Usuario foi informado
            if (tipoUsuarioAtualizado.Titulo != null)
            {
                // Se sim, altera o valor da propriedade Titulo
                tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;
            }

            // Atualiza o Tipo Usuario que foi buscado
            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarId(int IdTipoUsuario)
        {
            // Retorna o primeiro tipo Usuario encontrado para o ID informado
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == IdTipoUsuario);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            // Adiciona um novo Tipo Usuario
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int IdTipoUsuario)
        {
            // Busca um tipo Usuario através do seu id
            TipoUsuario tipoUsuarioBuscado = BuscarId(IdTipoUsuario);

            // Remove o TipoUsuario que foi buscado
            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            // Retorna uma lista com todas as informações dos Tipos Usuarios
            return ctx.TipoUsuarios.ToList();
        }

  
    }
}
