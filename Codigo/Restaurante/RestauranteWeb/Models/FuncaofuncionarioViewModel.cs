using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class FuncaofuncionarioViewModel
    {
        [Display(Name = "Código da função da Função")]
        [Required]
        [Key]
        public uint Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }
        
    }
}
