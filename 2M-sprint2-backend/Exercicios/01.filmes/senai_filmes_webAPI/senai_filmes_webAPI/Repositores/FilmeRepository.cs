using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositores
{
    public class FilmeRepository : IFilmeRepository
    {
        //private string stringConexao = @"Data Source=DESKTOP-5BM5L8P\SQLEXPRESS; initial catalog=CATALOGO; user id=sa; pwd=Senai@132;";
        private string stringConexao = @"Data Source=DESKTOP-5BM5L8P\SQLEXPRESS; initial catalog=CATALOGO; user id=sa; pwd=Senai@132;";

        public void AtualizarIdCorpo(FilmeDomain filmeAtualizado)
        {
            if (filmeAtualizado.tituloFilme != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE FILME SET tituloFilme = @novoNomeFilme WHERE idFilme = @idFilmeAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novoNomeFilme", filmeAtualizado.tituloFilme);
                        cmd.Parameters.AddWithValue("@idFilmeAtualizado", filmeAtualizado.idFilme);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                // "INSERT INTO GENERO (nomeGenero) VALUES ('Joana D'Arc')"
                // "INSERT INTO Generos (Nome) VALUES ('" + ')DROP TABLE Filmes-- + "')"
                // string queryInsert = "INSERT INTO GENERO (nomeGenero) VALUES ('" + novoGenero.nomeGenero + "')";

                // Não usar dessa forma, pois pode causar o efeito Joana D'Arc
                // Além de permitir SQL Injection 
                // Por exemplo
                // "nomeGenero" : "')DROP TABLE FILME--";

                // Ao tentar cadastrar um gênero com o comando acima, irá deletar a tabela FILME do banco de dados
                // https://www.devmedia.com.br/sql-injection/6102

                string queryInsert = "INSERT INTO FILME (tituloFilme) VALUES (@tituloFilme)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro @nomeGenero
                    cmd.Parameters.AddWithValue("@tituloFilme", novoFilme.tituloFilme);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();

                }
            }
        }
        public void Deletar(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM FILME WHERE idFilme = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idFilme, tituloFilme FROM Filme;";

                // Abre a conexão com o banco de dados, como se fosse no ssms "Conectar"
                con.Open();

                // Declarando SqlDataReader rdr percorrer a tabela do nosso banco de dados
                SqlDataReader rdr;

                // Declara SqlCommand passando a query que será executada e a conexão com parâmetros.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    // executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        // instancia um objeto genero do tipo FilmeDomain
                        FilmeDomain filme = new FilmeDomain()
                        {
                            // Atribui a propriedade idFilme
                            // valor da primeira coluna do banco de dados
                            idFilme = Convert.ToInt32(rdr[0]),

                            // atribui a propriedade nomeGenero
                            // valor da segunda coluna do banco de dados
                            tituloFilme = rdr[1].ToString()

                        };

                        // Adiciona o objeto genero criado a lista listaFilmes
                        listaFilmes.Add(filme);

                    }
                }
            };
            return listaFilmes;
        }
                    
        public void AtualizarIdUrl(int idFilme, FilmeDomain filme)
        {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateUrl = "UPDATE FILME SET tituloFilme = @novoNomeFilme WHERE idFilme = @idFilmeAtualizado";
                    using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                    {
                        cmd.Parameters.AddWithValue("@novoNomeFilme", filme.tituloFilme);
                        cmd.Parameters.AddWithValue("@idFilmeAtualizado", idFilme);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
        }

        public FilmeDomain BuscarPorId(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idFilme, tituloFilme FROM FILME WHERE idFilme = @idFilme";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idFilme", idFilme);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain
                        {
                            idFilme = Convert.ToInt32(reader["idFilme"]),

                            tituloFilme = reader["tituloFilme"].ToString()
                        };

                        return filmeBuscado;
                    }
                    return null;
                }
            }
        }

        FilmeDomain IFilmeRepository.BuscarPorId(int idFilme)
        {
            throw new NotImplementedException();
        }
    }
}
