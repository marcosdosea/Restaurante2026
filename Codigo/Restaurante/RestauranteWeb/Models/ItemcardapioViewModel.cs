using Core;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class ItemcardapioViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código obrigatório")]
        public uint Id { get; set; }
        [StringLength(45, ErrorMessage = "Nome deve ter até 45 caracteres")]
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Preço")]
        public decimal? Preco { get; set; }

        [StringLength(200, ErrorMessage = "Detalhes deve ter até 200 caracteres")]
        public string? Detalhes { get; set; }

        [Required(ErrorMessage = "Necessário informar se está ativo")]
        public sbyte Ativo { get; set; }

        [Required(ErrorMessage = "Restaurante associado obrigatório")]
        public uint IdRestaurante { get; set; }

        [Required(ErrorMessage = "Grupo de cardápio obrigatório")]
        public uint IdGrupoCardapio { get; set; }
    }
}
