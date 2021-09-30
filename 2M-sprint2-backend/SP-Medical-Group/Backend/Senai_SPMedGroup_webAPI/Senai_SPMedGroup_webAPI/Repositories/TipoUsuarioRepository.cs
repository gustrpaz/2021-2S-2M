using Senai_SPMedGroup_webAPI.Contexts;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        SpMedContext ctx = new SpMedContext();

        public void Atualizar(int IdTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            // Busca um TipoUsuario através do seu id

            TipoUsuario tipoUsuarioBuscado = BuscarId(IdTipoUsuario);

            // Verifica se o novo IdTipoUsuario que foi informado existe
            if (tipoUsuarioAtualizado.IdTipoUsuario.ToString() != null || tipoUsuarioAtualizado.TipoUsuario1 != null)
            {
                // Se sim, altera o valor da propriedade TipoUsuario
                tipoUsuarioBuscado.TipoUsuario1 = tipoUsuarioAtualizado.TipoUsuario1;
            }

            // Atualiza o TipoUsuario que foi buscado
            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarId(int IdTipoUsuario)
        {
            // Retorna o primeiro TipoUsuário encontrado para o ID informado
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == IdTipoUsuario); 
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            // Adiciona um novo Tipo Usuário
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int IdTipoUsuario)
        {
            // Busca um TipoUsuário através do seu id
            TipoUsuario tipoUsuarioBuscado = BuscarId(IdTipoUsuario);

            // Remove um tipo de usuário que foi buscado
            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            // Retorna uma lista com todas as informações dos Tipos de Usuários
            return ctx.TipoUsuarios.ToList(); 
        }
    }
}
