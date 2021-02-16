using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Models
{
    public class PessoaAccountModel
    {
        public PessoaModel Pessoa { get; set; }

        public AccountModel Account { get; set; }
    }
}
