using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-5BM5L8P\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132;";
        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.PLACA != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE VEICULO SET idVeiculo, idModelo, PLACA = @novoVeiculo WHERE idVeiculo = @idVeiculoAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novoVeiculo", veiculoAtualizado.idVeiculo);
                        cmd.Parameters.AddWithValue("@idVeiculoAtualizado", veiculoAtualizado.idModelo);
                        cmd.Parameters.AddWithValue("@idClienteAtualizado", veiculoAtualizado.PLACA);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            VeiculoDomain buscarVeiculo = new VeiculoDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idVeiculo, idModelo, PLACA FROM CLIENTE WHERE idVeiculo = @idVeiculo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        buscarVeiculo.idVeiculo = Convert.ToInt32(rdr[0]);
                        buscarVeiculo.idModelo = Convert.ToInt32(rdr[1]);
                        buscarVeiculo.PLACA = rdr[2].ToString();
                    }
                    return (buscarVeiculo);
                }
            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada

                string queryInsert = "INSERT INTO VEICULO (idModelo, PLACA) VALUES (@idModelo, @PLACA)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro @nomeCliente, @sobrenome
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@PLACA", novoVeiculo.PLACA);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idVeiculo, PLACA, nomeModelo FROM VEICULO V INNER JOIN MODELO M ON M.idModelo = V.idModelo;";

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
                        // instancia um objeto veiculo do tipo VeiculoDomain
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {

                            idVeiculo = Convert.ToInt32(rdr[0]),

                            idModelo = Convert.ToInt32(rdr[1]),

                            PLACA = rdr[2].ToString(),

                            modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[3].ToString()
                            }

                        };

                        // Adiciona o objeto veiculo criado a lista listaVeiculos
                        listaVeiculos.Add(veiculo);

                    }
                }
            };
            return listaVeiculos;
        }
    }
}
