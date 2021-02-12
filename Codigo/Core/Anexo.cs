using System;

namespace Core
{
    public partial class Anexo
    {
        public int IdAnexoPertence { get; set; }
        public string Nome { get; set; }
        public string UrlArquivo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int IdOcorrencia { get; set; }
        public int IdPessoa { get; set; }

        public virtual Ocorrencia IdOcorrenciaNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
