using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Models
{
    public class PertenceModel
    {
        [Display(Name = "Número cadastral")]
        [Key]
        [Required(ErrorMessage = "Não foi possivel identificar o número cadastral do tipo")]
        public int IdPertence { get; set; }

        [Display(Name = "Nome do Pertence")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Campo Nome deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Nome é obrigatório.")] 
        public string Nome { get; set; }

        [Display(Name = "Descrição sobre o Pertence")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Descricao deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Nome é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Status do Pertence")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Campo Status deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Nome é obrigatório.")]
        public string StatusPertence { get; set; }

        [Display(Name = "IdOcorrencia")]
        [Key]
        [Required(ErrorMessage = "Campo IdOcorrencia é obrigatório.")]
        public int IdOcorrencia { get; set; }
        
        [Display(Name = "IdTipoPertence")]
        [Key]
        [Required(ErrorMessage = "Campo IdTipoPertence é obrigatório.")] 
        public int IdTipoPertence { get; set; }
    }
}
