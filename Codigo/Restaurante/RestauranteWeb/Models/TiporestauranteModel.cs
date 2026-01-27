using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
	public class TiporestauranteModel
	{
		public uint Id { get; set; }

		[Required(ErrorMessage = "O nome do tipo de restaurante é obrigatório")]
		[StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
		public string Nome { get; set; } = string.Empty;
	}
}
