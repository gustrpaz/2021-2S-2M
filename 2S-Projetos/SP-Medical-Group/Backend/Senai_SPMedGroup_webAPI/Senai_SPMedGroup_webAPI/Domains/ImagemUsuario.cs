using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SPMedGroup_webAPI.Domains
{
    public partial class ImagemUsuario
    {
        public int IdImagemUsuario { get; set; }
        public int? IdUsuario { get; set; }
        public byte[] Binario { get; set; }
        public string MimeType { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime DataInclusao { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
