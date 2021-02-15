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
        [Key]
        public int? IdOcorrencia { get; set; }


        [Display(Name = "Data")] 
        public DateTime? DataOcorrencia { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(400, MinimumLength = 5, ErrorMessage = "Campo Descrição deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

       
        public string StatusOcorrencia { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Campo Telefone deve possuir no mínimo 9 caracteres.")]
        public string Telefone { get; set; }

        [Display(Name = "Emergência")]
        public string Emergencia { get; set; }
    }
}
