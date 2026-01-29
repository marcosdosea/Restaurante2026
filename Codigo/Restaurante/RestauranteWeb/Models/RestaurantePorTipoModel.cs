namespace RestauranteWeb.Models
{
    public class RestaurantePorTipoModel
    {
		public uint Id { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string? Cidade { get; set; }
		public string? Estado { get; set; }
		public string? Telefone { get; set; }
	}
}
