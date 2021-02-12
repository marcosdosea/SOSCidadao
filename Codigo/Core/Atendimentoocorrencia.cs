using System;

namespace Core
{
    public partial class Atendimentoocorrencia
    {
        public int IdAtendimentoOcorrencia { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdOcorrencia { get; set; }
        public int IdPessoa { get; set; }

        public virtual Ocorrencia IdOcorrenciaNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
