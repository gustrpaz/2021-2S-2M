using Microsoft.AspNetCore.Http;
using Senai_SPMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        // Valida o usuario
        Usuario Login(string email, string senha);

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns></returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario"></param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Deleta um Usuario
        /// </summary>
        /// <param name="IdUsuario"> id do Usuario que será deletado</param>
        void Deletar(int IdUsuario);


        /// <summary>
        /// Busca um Usuario pelo seu id
        /// </summary>
        /// <param name="IdUsuario">id do idUsuario que será buscado</param>
        /// <returns></returns>
        Usuario BuscarId(int IdUsuario);

        /// <summary>
        /// Atualiza os dados de um idUsuario existente
        /// </summary>
        /// <param name="IdUsuario">id do Usuario e que será atualizado</param>
        /// <param name="usuarioAtualizado">objeto idUsuarioAtualizado com as novas informações</param>
        void Atualizar(int IdUsuario, Usuario usuarioAtualizado);


        //IFormFile Representa um arquivo enviado com o HttpRequest.
        void SalvarPerfilBD(IFormFile foto, int IdUsuario);
        void SalvarPerfilDir(IFormFile foto, int IdUsuario);
        string ConsultarPerfilBD(int IdUsuario);
        string ConsultarPerfilDir(int IdUsuario);

    }
}
