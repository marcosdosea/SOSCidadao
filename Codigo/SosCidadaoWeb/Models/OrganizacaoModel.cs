using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Models
{
    public class OrganizacaoModel
    {
        [Display(Name = "Nº Cadastral")]
        public int? IdOrganizacao { get; set; }

        [Display(Name = "CNPJ")]
        [StringLength(14, MinimumLength = 5, ErrorMessage = "Campo Nome deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Cnpj é obrigatório.")]
        public string Cnpj { get; set; }

        [Display(Name = "Razao Social")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Campo Nome deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Razão Social é obrigatório.")]
        public string NomeRazao { get; set; }

        [Display(Name = "Nome Fantasia")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Campo Nome deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Nome Fantasia é obrigatório.")]
        public string NomeFantasia { get; set; }

        [Display(Name = "CEP")]
        [StringLength(9, ErrorMessage = "Campo CEP está incompleto", MinimumLength = 8)]
        [Required(ErrorMessage = "Campo CEP é obrigatório.")]
        public string Cep { get; set; }

        [Display(Name = "Rua/Avenida")]
        [StringLength(45, ErrorMessage = "Campo Rua/Avenida não permite mais que 45 caracteres")]
        [Required(ErrorMessage = "Campo Rua/Avenida é obrigatório.")]
        public string Rua { get; set; }

        [Display(Name = "Número")]
        [Range(0, int.MaxValue, ErrorMessage = "Campo Número do Endereço é inválido")]
        public int NumeroEndereco { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(45, ErrorMessage = "Campo Bairro não permite mais que 45 caracteres")]
        [Required(ErrorMessage = "Campo Bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(45, ErrorMessage = "Campo Cidade não permite mais que 45 caracteres")]
        [Required(ErrorMessage = "Campo Cidade é obrigatório.")]
        public string Cidade { get; set; }

        [Display(Name = "UF")]
        [StringLength(3, ErrorMessage = "Campo UF não permite mais que 2 caracteres")]
        [Required(ErrorMessage = "Campo UF é obrigatório.")]
        public string Uf { get; set; }

        [Display(Name = "Data de Registro")]
        public DateTime? DataRegistro { get; set; }

        [Display(Name = "Código da Pessoa vinculada a Organização")]
        public int? IdPessoa { get; set; }

    }
}
