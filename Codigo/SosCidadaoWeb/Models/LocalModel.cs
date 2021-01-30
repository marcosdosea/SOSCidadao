using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Models
{
    public class LocalModel
    {
        [Display(Name = "Nº Cadastral")]
        public int? IdLocal { get; set; }

        [Display(Name = "CEP")]
        [StringLength(8, ErrorMessage = "Campo CEP está incompleto", MinimumLength = 8)]
        [Required(ErrorMessage = "Campo CEP é obrigatório.")]
        public string Cep { get; set; }

        [Display(Name = "UF")]
        [StringLength(3, ErrorMessage = "Campo UF não permite mais que 2 caracteres")]
        [Required(ErrorMessage = "Campo UF é obrigatório.")]
        public string Uf { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(45, ErrorMessage = "Campo Cidade não permite mais que 45 caracteres")]
        [Required(ErrorMessage = "Campo Cidade é obrigatório.")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(45, ErrorMessage = "Campo Bairro não permite mais que 45 caracteres")]
        [Required(ErrorMessage = "Campo Bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Display(Name = "Rua/Avenida")]
        [StringLength(45, ErrorMessage = "Campo Rua/Avenida não permite mais que 45 caracteres")]
        [Required(ErrorMessage = "Campo Rua/Avenida é obrigatório.")]
        public string Rua { get; set; }

        [Display(Name = "Nº")]
        [Range(0, int.MaxValue, ErrorMessage = "Campo Número do Endereço é inválido")]
        public int? NumeroEndereco { get; set; }

        [Display(Name = "Nome")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Campo Nome deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Latitude")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Campo Número de Latitude é inválido")]
        public decimal? Latitude { get; set; }

        [Display(Name = "Longitude")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Campo Número de Longitude é inválido")]
        public decimal? Longitude { get; set; }
        
        [Display(Name = "Organização")]
        [Required(ErrorMessage = "Campo Organização é obrigatório.")]
        public int IdOrganizacao { get; set; }

    }
}
