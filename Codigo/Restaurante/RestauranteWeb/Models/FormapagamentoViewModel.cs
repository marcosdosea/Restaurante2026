using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class FormapagamentoViewModel
    {
		[Key]
		[Required(ErrorMessage = "O campo Id é obrigatório.")]
		public uint Id { get; set; }

		[Required(ErrorMessage = "O nome da forma de pagamento é obrigatório")]
		[StringLength(10, ErrorMessage = "O nome deve ter no máximo 10 caracteres")]
		public string Nome { get; set; } = null!;
	}
}
