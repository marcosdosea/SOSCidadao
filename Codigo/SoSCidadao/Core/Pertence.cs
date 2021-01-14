using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pertence
    {
        public int IdPertence { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string StatusPertence { get; set; }
        public int IdOcorrencia { get; set; }
        public int IdTipoPertence { get; set; }

        public virtual Ocorrencia IdOcorrenciaNavigation { get; set; }
        public virtual Tipopertence IdTipoPertenceNavigation { get; set; }
    }
}
