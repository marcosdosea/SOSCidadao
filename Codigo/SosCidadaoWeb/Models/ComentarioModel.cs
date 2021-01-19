using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Models
{
    public class ComentarioModel
    {
        public int idComentario = 0;

        [Display(Name = "Comentário")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Campo Nome deve possuir no mínimo 5 caracteres.")]
        [Required(ErrorMessage = "Campo Comentário é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Nº Cadastral Pessoa")]
        [Range(0, int.MaxValue, ErrorMessage = "Não foi possível identificar a Pessoa dona do comentário")]
        [Required(ErrorMessage = "Campo Comentário é obrigatório.")]
        public string IidPessoa { get; set; }

        [Display(Name = "Nº Cadastral Ocorrencia")]
        [Range(0, int.MaxValue, ErrorMessage = "Não foi possível identificar a Ocorrência")]
        [Required(ErrorMessage = "Campo Ocorrencia é obrigatório.")]
        public string idOcorrencia { get; set; }


    }
}
