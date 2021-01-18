using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Ocorrenciatipoocorrencia
    {
        public int IdOcorrenciaTipoOcorrencia { get; set; }
        public int IdOcorrencia { get; set; }
        public int IdTipoOcorrencia { get; set; }

        public virtual Ocorrencia IdOcorrenciaNavigation { get; set; }
        public virtual Tipoocorrencia IdTipoOcorrenciaNavigation { get; set; }
    }
}
