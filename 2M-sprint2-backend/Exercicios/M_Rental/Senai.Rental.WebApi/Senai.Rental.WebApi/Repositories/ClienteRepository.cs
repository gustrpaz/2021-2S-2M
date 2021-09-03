using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private string stringConexao = @"Data Source=DESKTOP-5BM5L8P\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132;";
        public void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.nomeCliente != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE CLIENTE SET idCliente, nomeCliente, sobrenome = @novoCliente WHERE idCliente = @idClienteAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novoCliente", clienteAtualizado.idCliente);
                        cmd.Parameters.AddWithValue("@idClienteAtualizado", clienteAtualizado.nomeCliente);
                        cmd.Parameters.AddWithValue("@idClienteAtualizado", clienteAtualizado.sobrenome);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            ClienteDomain buscarCliente = new ClienteDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idCliente, nomeCliente, sobrenome FROM CLIENTE WHERE idCliente = @idCliente;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        buscarCliente.idCliente = Convert.ToInt32(rdr[0]);
                        buscarCliente.nomeCliente = rdr[1].ToString();
                        buscarCliente.sobrenome = rdr[2].ToString();
                    }
                    return (buscarCliente);
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada

                string queryInsert = "INSERT INTO CLIENTE (nomeCliente,sobrenome) VALUES (@nomeCliente, @sobrenome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro @nomeCliente, @sobrenome
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenome", novoCliente.sobrenome);
                  
                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idCliente, nomeCliente, sobrenome FROM CLIENTE;";

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
                        // instancia um objeto aluguel do tipo ClienteDomain
                        ClienteDomain cliente = new ClienteDomain()
                        {

                            idCliente = Convert.ToInt32(rdr[0]),

                            nomeCliente = rdr[1].ToString(),

                            sobrenome = rdr[2].ToString()

                        };

                        // Adiciona o objeto cliente criado a lista listaClientes
                        listaClientes.Add(cliente);

                    }
                }
            };
            return listaClientes;
        }
    }
}
