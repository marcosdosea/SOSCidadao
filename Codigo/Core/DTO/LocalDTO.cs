﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class LocalDTO
    {
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
        public string NomeOrganizacao { get; set; }
    }
}
