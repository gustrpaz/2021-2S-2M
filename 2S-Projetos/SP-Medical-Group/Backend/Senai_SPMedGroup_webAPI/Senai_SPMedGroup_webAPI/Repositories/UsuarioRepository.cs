using Microsoft.AspNetCore.Http;
using Senai_SPMedGroup_webAPI.Contexts;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        SpMedContext ctx = new SpMedContext();
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void Atualizar(int IdUsuario, Usuario usuarioAtualizado)
        {
            // Busca um usuario através do seu id

            Usuario usuarioBuscado = BuscarId(IdUsuario);

            // Verifica se o novo idUsuario que foi informado existe
            if (usuarioAtualizado.Email != null || usuarioAtualizado.Senha != null || usuarioAtualizado.IdTipoUsuario != null)
            {
                // Se sim, altera o valor da propriedade Usuario, podendo dar um novo cargo a ele(a)
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            // Atualiza o Usuario que foi buscado
            ctx.Usuarios.Update(usuarioBuscado);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            // Retorna uma lista com todas as informações dos Usuários
            
            return ctx.Usuarios.Select(x => new Usuario
            {
                IdTipoUsuarioNavigation = x.IdTipoUsuarioNavigation,
                IdUsuario = x.IdUsuario,
                Email = x.Email,
            }).ToList();
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

        public Usuario BuscarId(int IdUsuario)
        {
            // Retorna o primeiro Usuário encontrado para o ID informado
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == IdUsuario);
        }

        public void SalvarPerfilBD(IFormFile foto, int IdUsuario)
        {
            //instancia do objeto ImagemUsuario para gravar o arquivo no BD.
            ImagemUsuario imagemUsuario = new ImagemUsuario();

            using (var ms = new MemoryStream())
            {
                //copia a imagem enviada para a memoria.
                foto.CopyTo(ms);
                //ToArray = são os bytes da imagem.
                imagemUsuario.Binario = ms.ToArray();
                //nome do arquivo
                imagemUsuario.NomeArquivo = foto.FileName;
                //extensão do arquivo
                imagemUsuario.MimeType = foto.FileName.Split('.').Last();
                //id_usuario
                imagemUsuario.IdUsuario = IdUsuario;
            }

            //ANALISAR SE O USUARIO JA POSSUI FOTO DE PERFIL
            ImagemUsuario fotoexistente = new ImagemUsuario();
            fotoexistente = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == IdUsuario);

            if (fotoexistente != null)
            {
                fotoexistente.Binario = imagemUsuario.Binario;
                fotoexistente.NomeArquivo = imagemUsuario.NomeArquivo;
                fotoexistente.MimeType = imagemUsuario.MimeType;
                fotoexistente.IdUsuario = IdUsuario;

                //atualiza a imagem de perfil do usuario.
                ctx.ImagemUsuarios.Update(fotoexistente);
            }
            else
            {
                ctx.ImagemUsuarios.Add(imagemUsuario);
            }

            //salvar as modificações.
            ctx.SaveChanges();
        
    }

        public void SalvarPerfilDir(IFormFile foto, int IdUsuario)
        {
            //Define o nome do arquivo com o ID do Usuario + .png
            string nome_novo = IdUsuario.ToString() + ".png";

            //FileStreama fornece uma exibicao para para uma sequencia de bytes.
            //dando suporte para leitura e gravação.

            using (var stream = new FileStream(Path.Combine("perfil", nome_novo), FileMode.Create))
            {
                //copia todos os elementos (array de bytes) para o caminho indicado.
                foto.CopyTo(stream);
            }
        }

        public string ConsultarPerfilBD(int IdUsuario)
        {
            ImagemUsuario imagemUsuario = new ImagemUsuario();

            imagemUsuario = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == IdUsuario);

            if (imagemUsuario != null)
            {
                //Converte o valor de uma matriz de inteiros (array de binarios) em string.
                return Convert.ToBase64String(imagemUsuario.Binario);
            }

            return null;
        }

        public string ConsultarPerfilDir(int IdUsuario)
        {
            string nome_novo = IdUsuario.ToString() + ".png";
            string caminho = Path.Combine("Perfil", nome_novo);

            //analisa se o arquivo existe.
            if (File.Exists(caminho))
            {
                //recupera o array de bytes.
                byte[] bytesArquivo = File.ReadAllBytes(caminho);
                //converte em base 64.
                return Convert.ToBase64String(bytesArquivo);
            }

            return null;
        }
    }
}
