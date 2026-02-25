using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class PagamentoViewModel
    {
        [Required]
        public uint IdAtendimento { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        [Display(Name = "Valor do Pagamento (R$)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Selecione a forma de pagamento")]
        [Display(Name = "Forma de Pagamento")]
        public uint IdFormaPagamento { get; set; }

        public decimal TotalAtendimento { get; set; }
        public decimal ValorFaltante { get; set; }
    }
}