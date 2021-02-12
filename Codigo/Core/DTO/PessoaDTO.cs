using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class PessoaDTO
    {
        public int IdPessoa { get; set; }

        public string Nome { get; set; }

        public string Sexo { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cidade { get; set; }

        public string TipoPessoa { get; set; }

        public string StatusPessoa { get; set; }

        public DateTime DataCadastro { get; set; }

        public string NomeOrganizacao { get; set; }

    }
}
