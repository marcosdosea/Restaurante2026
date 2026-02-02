using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
	public class TiporestauranteViewModel
	{
		
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
		public uint Id { get; set; }

		[Required(ErrorMessage = "O nome do tipo de restaurante é obrigatório")]
		[StringLength(30, ErrorMessage = "O nome deve ter no máximo 30 caracteres")]
		public string Nome { get; set; } = null!;

	
	}
}
