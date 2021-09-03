using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório VeiculoRepository
    /// </summary>
    interface IVeiculoRepository
    {
        // Estrutura de métodos da Interface
        // TipoRetorno NomeMetodo (TipoParametro NomeParametro);
        // void Cadastrar(VeiculoDomain novoVeiculo);

        /// <summary>
        /// Retorna todos os veiculos
        /// </summary>
        /// <returns>Uma lista de veiculos</returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// Busca um veículo através do seu id
        /// </summary>
        /// <param name="idVeiculo">id do veículo que será buscado</param>
        /// <returns>Um objeto do tipo VeiculoDomain que foi buscado</returns>
        VeiculoDomain BuscarPorId(int idVeiculo);

        /// <summary>
        /// Cadastra um novo Veículo
        /// </summary>
        /// <param name="novoVeiculo">Objeto novoVeiculo com os dados que serão cadastrados</param>
        void Cadastrar(VeiculoDomain novoVeiculo);


        /// <summary>
        /// Atualiza um veículo existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idVeiculo">id do veículo que será atualizado</param>
        /// <param name="veiculoAtualizado">Objeto veiculoAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/veiculo/4
        void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado);

        /// <summary>
        /// Deleta um veiculo
        /// </summary>
        /// <param name="idVeiculo">id do veiculo que será deletado</param>
        void Deletar(int idVeiculo);
    }
}
