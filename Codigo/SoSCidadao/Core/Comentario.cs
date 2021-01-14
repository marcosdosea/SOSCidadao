using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Comentario
    {
        public int IdComentario { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
        public int IdOcorrencia { get; set; }

        public virtual Ocorrencia IdOcorrenciaNavigation { get; set; }
    }
}
