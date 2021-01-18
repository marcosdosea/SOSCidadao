using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Anexo = new HashSet<Anexo>();
            Atendimentoocorrencia = new HashSet<Atendimentoocorrencia>();
            Comentario = new HashSet<Comentario>();
            Ocorrencia = new HashSet<Ocorrencia>();
            Organizacao = new HashSet<Organizacao>();
        }

        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int? NumeroEndereco { get; set; }
        public string TipoPessoa { get; set; }
        public string StatusPessoa { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? IdOrganizacao { get; set; }

        public virtual Organizacao IdOrganizacaoNavigation { get; set; }
        public virtual ICollection<Anexo> Anexo { get; set; }
        public virtual ICollection<Atendimentoocorrencia> Atendimentoocorrencia { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Ocorrencia> Ocorrencia { get; set; }
        public virtual ICollection<Organizacao> Organizacao { get; set; }
    }
}
