using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class AtendimentoViewModel
    {
        
        [Display(Name = "Código")]
        [Required(ErrorMessage = "id obrigatorio")]
        [Key]
        public uint Id { get; set; }
        
        [Display(Name = "Hora de Início")]
        [Required(ErrorMessage = "hora de inicio obrigatorio")]
        public DateTime DataHoraInicio { get; set; }
        
        [Display(Name = "Hora de Fim")]
        public DateTime? DataHoraFim { get; set; }

        /// <summary>
        /// I - INICIADO
        /// C- CANCELADO
        /// F - FINALIZADO
        /// 
        /// </summary>
        [Required(ErrorMessage = "status obrigatorio")]
        public string Status { get; set; } = null!;

        [Display(Name = "Total da Conta")]
        [Required(ErrorMessage = "total da conta obrigatorio")]
        public decimal TotalConta { get; set; }

        [Display(Name = "Total do Serviço")]
        [Required(ErrorMessage = "total do serviço obrigatorio")]
        public decimal TotalServico { get; set; }

        [Display(Name = "Total do Desconto")]
        [Required(ErrorMessage = "total do desconto obrigatorio")]
        public decimal TotalDesconto { get; set; }

        [Required(ErrorMessage = "total obrigatorio")]
        public decimal Total { get; set; }

        [Display(Name = "Mesa")]
        [Required(ErrorMessage = "id da mesa obrigatorio")] 
        public int IdMesa { get; set; }

        public SelectList? ListaMesas { get; set; }
    }
}
