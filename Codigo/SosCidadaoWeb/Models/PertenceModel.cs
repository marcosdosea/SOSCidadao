using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Models
{
    public class PertenceModel
    {
        [Display(Name = "Nº Cadastral")]
        public int? IdPertence { get; set; }

        [Display(Name = "Nome ")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Campo Nome deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Nome é obrigatório.")] 
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Descricao deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Nome é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Status")]
        public string StatusPertence { get; set; }

        [Display(Name = "Ocorrênca")]
        [Key]
        [Required(ErrorMessage = "Campo IdOcorrencia é obrigatório.")]
        public int IdOcorrencia { get; set; }
        
        [Display(Name = "Tipo")]
        [Key]
        [Required(ErrorMessage = "Campo IdTipoPertence é obrigatório.")] 
        public int IdTipoPertence { get; set; }
    }
}
