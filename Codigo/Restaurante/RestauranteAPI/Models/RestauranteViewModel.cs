using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Util;

namespace RestauranteWeb.Models
{
    public class RestauranteViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Codigo obrigatorio")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Código Tipo Restaurante")]
        [Required(ErrorMessage = "Codigo do tipo de restaurante obrigatorio")]
        public uint IdTipoRestaurante { get; set; }

        [Required(ErrorMessage = "campo obrigatorio")]
        public string Cnpj { get; set; } = null!;

        [Required(ErrorMessage = "campo obrigatorio")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome do restaurante deve ter entre 5 e 45 caracteres")]
        public string Nome { get; set; } = null!;

        [StringLength(8, ErrorMessage = "CEP deve ter até 8 caracteres")]
        public string? Cep { get; set; }

        [StringLength(45, ErrorMessage = "Rua deve ter até 45 caracteres")]
        public string? Rua { get; set; }

        [StringLength(45, ErrorMessage = "Bairro deve ter até 45 caracteres")]
        public string? Bairro { get; set; }

        [StringLength(45, ErrorMessage = "Cidade deve ter até 45 caracteres")]
        public string? Cidade { get; set; }

        [StringLength(2, ErrorMessage = "Estado deve ter até 2 caracteres")]
        public string? Estado { get; set; }

        [StringLength(14, ErrorMessage = "Número deve ter até 14 caracteres")]
        public string? Telefone1 { get; set; }

        [StringLength(14, ErrorMessage = "Número deve ter até 14 caracteres")]
        public string? Telefone2 { get; set; }

        public SelectList? ListaTiposRestaurantes { get; set; }
    }
}
