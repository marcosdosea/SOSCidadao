using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Models
{
    public class TipopertenceModel
    {
		[Display(Name = "Número cadastral")]
		[Key]
		[Required(ErrorMessage = "Não foi possivel identificar o número cadastral do tipo")]
		public int IdTipoPertence { get; set; }

		[Display(Name = "Nome do Tipo do Pertence")]
		[StringLength(45, MinimumLength = 5, ErrorMessage = "Campo Nome deve possuir no mínimo 5 caracteres.")]
		[Required(ErrorMessage = "Campo Nome é obrigatório.")]
		public string Nome { get; set; }
	}
}
