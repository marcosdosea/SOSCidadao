﻿using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Tipoocorrencia
    {
        public Tipoocorrencia()
        {
            Ocorrenciatipoocorrencia = new HashSet<Ocorrenciatipoocorrencia>();
        }

        public int IdTipoOcorrencia { get; set; }
        public string Nome { get; set; }
        public int IdOrganizacao { get; set; }

        public virtual Organizacao IdOrganizacaoNavigation { get; set; }
        public virtual ICollection<Ocorrenciatipoocorrencia> Ocorrenciatipoocorrencia { get; set; }
    }
}
