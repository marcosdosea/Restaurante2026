using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class FuncaofuncionarioViewModel
    {
        [Required]
        [Key]
        public uint Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }
        [Required]
        public virtual SelectList? Funcionarios { get; set; }
    }
}
