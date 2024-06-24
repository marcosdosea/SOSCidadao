using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Ocorrencia
    {
        public Ocorrencia()
        {
            Anexo = new HashSet<Anexo>();
            Atendimentoocorrencia = new HashSet<Atendimentoocorrencia>();
            Comentario = new HashSet<Comentario>();
            Ocorrenciatipoocorrencia = new HashSet<Ocorrenciatipoocorrencia>();
            Pertence = new HashSet<Pertence>();
        }

        public int IdOcorrencia { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
        public string StatusOcorrencia { get; set; }
        public string TelefoneContato { get; set; }
        public byte Emergencia { get; set; }
        public int? IdPessoaSolicitante { get; set; }
        public int IdLocal { get; set; }

        public virtual Local IdLocalNavigation { get; set; }
        public virtual Pessoa IdPessoaSolicitanteNavigation { get; set; }
        public virtual ICollection<Anexo> Anexo { get; set; }
        public virtual ICollection<Atendimentoocorrencia> Atendimentoocorrencia { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Ocorrenciatipoocorrencia> Ocorrenciatipoocorrencia { get; set; }
        public virtual ICollection<Pertence> Pertence { get; set; }
    }
}
