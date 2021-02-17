using System;
using System.ComponentModel.DataAnnotations;

namespace SosCidadaoWeb.Models
{
    public class PessoaModel
    {
        [Display(Name = "Nº Cadastral")]
        public int? idPessoa { get; set; }

        [Display(Name = "Nome Completo")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Campo Nome deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Campo Sexo é obrigatório.")]
        public string Sexo { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Campo CPF deve possuir no mínimo 11 digitos.")]
        public string Cpf { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento informada é inválida")]
        [DisplayFormat(DataFormatString = "{0:dd//mm//yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail informado é inválido.")]
        [Required(ErrorMessage = "Campo E-mail é obrigatório.")]
        public string Email { get; set; }

        [Display(Name = "CEP")]
        [StringLength(9, ErrorMessage = "Campo CEP está incompleto", MinimumLength = 9)]
        [Required(ErrorMessage = "Campo CEP é obrigatório.")]
        public string Cep { get; set; }

        [Display(Name = "Logradouro")]
        [StringLength(45, ErrorMessage = "Campo Logradouro não permite mais que 45 caracteres")]
        [Required(ErrorMessage = "Campo Rua/Avenida é obrigatório.")]
        public string Rua { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(45, ErrorMessage = "Campo Bairro não permite mais que 45 caracteres")]
        [Required(ErrorMessage = "Campo Bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(45, ErrorMessage = "Campo Cidade não permite mais que 45 caracteres")]
        [Required(ErrorMessage = "Campo Cidade é obrigatório.")]
        public string Cidade { get; set; }

        [Display(Name = "UF")]
        [StringLength(2, ErrorMessage = "Campo UF não permite mais que 2 caracteres")]
        [Required(ErrorMessage = "Campo UF é obrigatório.")]
        public string Uf { get; set; }

        [Display(Name = "Nº")]
        [Range(0, int.MaxValue, ErrorMessage = "Campo Número do Endereço é inválido")]
        public int? NumeroEndereco { get; set; }

        [Display(Name = "Tipo Pessoa")]
        public string TipoPessoa { get; set; }
        public string StatusPessoa { get; set; }
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Organização")]
        public int? IdOrganizacao { get; set; }
    }
}
