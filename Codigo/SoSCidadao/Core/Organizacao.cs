﻿using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Organizacao
    {
        public Organizacao()
        {
            Local = new HashSet<Local>();
            Pessoa = new HashSet<Pessoa>();
        }

        public int IdOrganizacao { get; set; }
        public string NomeRazao { get; set; }
        public string NomeFantasia { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Uf { get; set; }
        public int? NumeroEndereco { get; set; }
        public DateTime DataRegistro { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Local> Local { get; set; }
        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}
