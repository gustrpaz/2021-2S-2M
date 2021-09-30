using Senai_SPMedGroup_webAPI.Contexts;
using Senai_SPMedGroup_webAPI.Domains;
using Senai_SPMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        SpMedContext ctx = new SpMedContext();
        public void Atualizar(int IdSituacao, Situacao situacaoAtualizada)
        {
            // Busca uma Situacao através do seu id

            Situacao situacaoBuscada = BuscarId(IdSituacao);

            // Verifica se a nova Situacao que foi informado existe
            if (situacaoAtualizada.Situacao1 != null)
            {
                // Se sim, altera o valor da propriedade Situacao
                situacaoBuscada.Situacao1 = situacaoAtualizada.Situacao1;

            }
            // Atualiza a Situacao que foi buscada
            ctx.Situacaos.Update(situacaoBuscada);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Situacao BuscarId(int IdSituacao)
        {
            // Retorna a primeira Situacao encontrada para o ID informado
            return ctx.Situacaos.FirstOrDefault(e => e.IdSituacao == IdSituacao);
        }


        public List<Situacao> ListarTodos()
        {
            // Retorna uma lista com todas as informações das Situacao
            return ctx.Situacaos.ToList();
        }
    }
}
