using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class ComentarioDTO
    {
        public int IdComentario { get; set; }

        public int IdPessoa { get; set; }

        public string Descricao { get; set; }

        public string DataCadastro { get; set; }
    }
}
