using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? Preco { get; set; }

        [StringLength(200, ErrorMessage = "Detalhes deve ter até 200 caracteres")]
        public string? Detalhes { get; set; }

        [Required(ErrorMessage = "Necessário informar se está ativo")]
        public sbyte Ativo { get; set; }

        [Required(ErrorMessage = "Restaurante associado obrigatório")]
        [Display(Name = "Restaurante")]
        public uint IdRestaurante { get; set; }

        [Required(ErrorMessage = "Grupo de cardápio obrigatório")]
        [Display(Name = "Cardápio")]
        public uint IdGrupoCardapio { get; set; }

        public string Status => Ativo == 1 ? "Disponível" : "Indisponível";

        [Display(Name = "Restaurante")]
        public string NomeRestaurante { get; set; } = "";

        public SelectList? ListaRestaurantes { get; set; }
        public SelectList? ListaCardapios { get; set; }
    }
}
