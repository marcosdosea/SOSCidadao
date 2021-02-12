using System.Collections.Generic;

namespace Core
{
    public partial class Local
    {
        public Local()
        {
            Ocorrencia = new HashSet<Ocorrencia>();
        }

        public int IdLocal { get; set; }
        public string Nome { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int? NumeroEndereco { get; set; }
        public int IdOrganizacao { get; set; }

        public virtual Organizacao IdOrganizacaoNavigation { get; set; }
        public virtual ICollection<Ocorrencia> Ocorrencia { get; set; }
    }
}
