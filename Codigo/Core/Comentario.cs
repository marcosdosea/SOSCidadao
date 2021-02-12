using System;

namespace Core
{
    public partial class Comentario
    {
        public int IdComentario { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
        public int IdOcorrencia { get; set; }
        public int IidPessoa { get; set; }

        public virtual Ocorrencia IdOcorrenciaNavigation { get; set; }
        public virtual Pessoa IidPessoaNavigation { get; set; }
    }
}
