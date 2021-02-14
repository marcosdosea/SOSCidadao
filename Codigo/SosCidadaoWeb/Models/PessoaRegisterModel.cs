using SosCidadaoWeb.Areas.Identity.Pages.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Models
{
    public class PessoaRegisterModel
    {
        public PessoaModel pessoa { get; set; }

        public RegisterModel.InputModel register { get; set; }
    }
}
