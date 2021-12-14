using Senai_SPMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedGroup_webAPI.Interfaces
{
    interface ILocalizacaoRepository
    {
        List<Localizacao> ListarTodas();

        void Cadastrar(Localizacao novaLocalizacao);

       
    }
}
