﻿using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Tipopertence
    {
        public Tipopertence()
        {
            Pertence = new HashSet<Pertence>();
        }

        public int IdTipoPertence { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Pertence> Pertence { get; set; }
    }
}
