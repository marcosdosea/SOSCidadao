using System;

namespace Core.DTO
{
    public class ComentarioDTO
    {
        public int IdComentario { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
        public int IdOcorrencia { get; set; }
        public string NomePessoa { get; set; }
    }
}
