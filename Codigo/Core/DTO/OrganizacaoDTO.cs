using System;

namespace Core.DTO
{
    public class OrganizacaoDTO
    {
        public int IdOrganizacao { get; set; }
        public string Cnpj { get; set; }
        public string NomeRazao { get; set; }
        public string NomeFantasia { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int? NumeroEndereco { get; set; }
        public DateTime DataRegistro { get; set; }
        public string NomePessoa { get; set; }
    }
}
