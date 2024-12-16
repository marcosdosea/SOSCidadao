using System;

namespace Core.DTO
{
    public class OcorrenciaDTO
    {
        public int IdOcorrencia { get; set; }
        public DateTime DataCadastro { get; set; }
        public string StatusOcorrencia { get; set; }
        public string Descricao { get; set; }
        public byte Emergencia { get; set; }
        public int IdLocal { get; set; }
    }
}
