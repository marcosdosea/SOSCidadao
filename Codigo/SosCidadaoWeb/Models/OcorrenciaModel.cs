using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Models
{
    public class OcorrenciaModel
    {
        [Display(Name = "Nº Cadastral")]
        public int? IdOcorrencia { get; set; }

        [Display(Name = "Data da Ocorrência")]
        [DataType(DataType.Date, ErrorMessage = "Data da ocorrência informada é inválida")]
        [DisplayFormat(DataFormatString = "{0:dd//mm//yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo Data da Ocorrência é obrigatório.")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Status da Ocorrência")]
              
        public string StatusOcorrencia { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(300, ErrorMessage = "A Descrição tem que ter no minimo 10 caracter", MinimumLength = 10)]
        [Required(ErrorMessage = "Campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Emergência")]
        public byte Emergencia { get; set; }

        [Display(Name = "Local")]
        public int IdLocal { get; set; }

              
    }
}
