using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        //private string stringConexao = @"Data Source=DESKTOP-5BM5L8P\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132;";
        private string stringConexao = @"Data Source=DESKTOP-5BM5L8P\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132;";

        public void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.veiculo != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE ALUGUEL SET idAluguel, idVeiculo, DataDevol, DataRetirada = @novoAluguel WHERE idAluguel = @idAluguelAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novoAluguel", aluguelAtualizado.idAluguel);
                        cmd.Parameters.AddWithValue("@idAluguelAtualizado", aluguelAtualizado.idVeiculo);
                        cmd.Parameters.AddWithValue("@idAluguelAtualizado", aluguelAtualizado.DataDevol);
                        cmd.Parameters.AddWithValue("@idAluguelAtualizado", aluguelAtualizado.DataRetirada);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        // INCOMPLETO
        public AluguelDomain BuscarPorId(int idAluguel)
        {
            AluguelDomain buscarAluguel = new AluguelDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idAluguel, DataDevol, DataRetirada, A.idVeiculo FROM VEICULO VINNER JOIN ALUGUEL A ON V.idVeiculo = V.idVeiculo WHERE A.idVeiculo = @idVeiculo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        buscarAluguel.idAluguel = Convert.ToInt32(rdr[0]);
                        buscarAluguel.DataDevol = Convert.ToDateTime(rdr[1]);
                        buscarAluguel.idVeiculo = Convert.ToInt32(rdr[2]);
                        buscarAluguel.DataRetirada = Convert.ToDateTime(rdr[3]);
                        buscarAluguel.veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[2]),
                            modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[4].ToString()
                            }
                        };
                    }
                    return (buscarAluguel);
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
       
                string queryInsert = "INSERT INTO ALUGUEL (idVeiculo, idCliente, DataDevol, DataRetirada) VALUES (@idVeiculo, @idCliente, @DataDevol, @DataRetirada)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro @idVeiculo, @idCliente, @DataDevol
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@DataDevol", novoAluguel.DataDevol);
                    cmd.Parameters.AddWithValue("@DataRetirada", novoAluguel.DataRetirada);
                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idAluguel, nomeCliente, sobrenome, DataDevol, DataRetirada, nomeModelo, PLACA FROM ALUGUEL A INNER JOIN VEICULO V ON A.idVeiculo = V.idVeiculo INNER JOIN MODELO M ON M.idModelo = V.idModelo INNER JOIN CLIENTE C ON C.idCliente = A.idCliente;";

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
                        // instancia um objeto aluguel do tipo AluguelDomain
                        AluguelDomain aluguel = new AluguelDomain()
                        {   //      Ordem
                            // [0] idAluguel
                            // [1] nomeCliente
                            // [2] sobrenome
                            // [3] DataDevol
                            // [4] DataRetirada
                            // [5] nomeModelo
                            // [6] Placa

                            idAluguel = Convert.ToInt16(rdr[0]),

                            cliente = new ClienteDomain()
                            {
                                nomeCliente = rdr[1].ToString(),
                                sobrenome = rdr[2].ToString()
                            },

                            

                            DataDevol = Convert.ToDateTime(rdr[3]),

                            DataRetirada = Convert.ToDateTime(rdr[4]),

                            modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[5].ToString()
                            },

                            veiculo = new VeiculoDomain()
                            {
                                PLACA = rdr[6].ToString()
                            }

                        };

                        // Adiciona o objeto aluguel criado a lista listaAlugueis
                        listaAlugueis.Add(aluguel);

                    }
                }
            };
            return listaAlugueis;
        }
    }
}
