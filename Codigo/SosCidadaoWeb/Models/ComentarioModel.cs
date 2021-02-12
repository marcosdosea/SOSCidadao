using System;
using System.ComponentModel.DataAnnotations;

namespace SosCidadaoWeb.Models
{
    public class ComentarioModel
    {
        [Display(Name = "Nº Cadastral")]
        public int? IdComentario { get; set; }

        [Display(Name = "Comentário")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Campo Nome deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Comentário é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Nº Cadastral Pessoa")]
        [Range(0, int.MaxValue, ErrorMessage = "Não foi possível identificar a Pessoa dona do comentário")]
        [Required(ErrorMessage = "Campo Comentário é obrigatório.")]
        public string IidPessoa { get; set; }

        public string DataCadastro { get; set; }

        [Display(Name = "Nº Cadastral Ocorrencia")]
        [Range(0, int.MaxValue, ErrorMessage = "Não foi possível identificar a Ocorrência")]
        [Required(ErrorMessage = "Campo Ocorrencia é obrigatório.")]
        public string IdOcorrencia { get; set; }
    }
}
