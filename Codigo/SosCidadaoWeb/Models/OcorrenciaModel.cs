using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Models
{
    public class OcorrenciaModel
    {
        [Display(Name = "Código da Ocorrência")]
        [Key]
        [Required(ErrorMessage = "Campo código é obrigatório.")]
        public int? IdOcorrencia { get; set; }

        public DateTime? DataOcorrencia { get; set; }

        [Display(Name = "Descrição da Ocorrência")]
        [StringLength(400, MinimumLength = 5, ErrorMessage = "Campo Descrição deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Status da Ocorrência")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Campo Status deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Status é obrigatório.")]
        public string StatusOcorrencia { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Campo Telefone deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Display(Name = "Emergência")]
        [StringLength(10, ErrorMessage = "Campo Emergencia está incompleto", MinimumLength = 3)]
        [Required(ErrorMessage = "Campo Emergencia é obrigatório.")]
        public string Emergencia { get; set; }
    }
}
