using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositores
{
    /// <summary>
    /// Classe responsável pelo repositorio dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros.
        /// Data Source = Nome do Servidor
        /// initial catalog = Nome do banco de dados
        /// User id = sa; pwd = senha = Faz autenticação com o SQL SERVER passando o login e a senha;
        /// integrated security = true = Faz autenticação com o usuário de sistema (Windows)
        /// </summary>
        private string stringConexao = @"Data Source=DESKTOP-5BM5L8P\SQLEXPRESS; initial catalog=CATALOGO; user id=sa; pwd=Senai@132;";
        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            if (generoAtualizado.nomeGenero != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE GENERO SET nomeGenero = @novoNomeGen WHERE idGenero = @idGenAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novoNomeGen", generoAtualizado.nomeGenero);
                        cmd.Parameters.AddWithValue("@idGenAtualizado", generoAtualizado.idGenero);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao)) 
            {
                string queryUpdateUrl = "UPDATE GENERO SET nomeGenero = @novoNome WHERE idGenero = @idGenAtualizado";
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeGen", generoAtualizado.nomeGenero);
                    cmd.Parameters.AddWithValue("@idGenAtualizado", idGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idGenero, nomeGenero FROM GENERO WHERE idGenero = @idGenero";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);

                    reader = cmd.ExecuteReader();

                    if (reader.Read()) 
                    {
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            idGenero = Convert.ToInt32(reader["idGenero"]),

                            nomeGenero = reader["nomeGenero"].ToString()
                        };

                        return generoBuscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastrar um novo gênero.
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
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

                string queryInsert = "INSERT INTO GENERO (nomeGenero) VALUES (@nomeGenero)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro @nomeGenero
                    cmd.Parameters.AddWithValue("@nomeGenero", novoGenero.nomeGenero);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int idGenero)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM GENERO WHERE idGenero = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con)) 
                {
                    cmd.Parameters.AddWithValue("@id", idGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns> Lista de gêneros </returns>
        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();


            // Declara a SqlConnection con passando a string de conexão como Parâmetro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string querySelectAll = "SELECT idGenero, nomeGenero FROM GENERO;";

                // Abre a conexão com o banco de dados, como se fosse no ssms "Conectar"
                con.Open();


                // Declarando SqlDataReader rdr percorrer a tabela do nosso banco de dados
                SqlDataReader rdr;

                // Declara SqlCommand passando a query que será executada e a conexão com parâmetros.
                using(SqlCommand cmd = new SqlCommand(querySelectAll, con)) 
                {

                    // executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        // instancia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui a propriedade idGenero
                            // valor da primeira coluna do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),

                            // atribui a propriedade nomeGenero
                            // valor da segunda coluna do banco de dados
                            nomeGenero = rdr[1].ToString()

                        };

                        // Adiciona o objeto genero criado a lista listaGeneros
                        listaGenero.Add(genero);
                    }
                }

            };
            return listaGenero;
        }
    }
}
