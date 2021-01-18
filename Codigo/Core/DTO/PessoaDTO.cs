using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class PessoaDTO
    {
        public int IdPessoa { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string TipoPessoa { get; set; }

        public string Senha { get; set; }

        public string StatusPessoa { get; set; }

        public int IdOrganizacao { get; set; }
    }
}
