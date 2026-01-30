using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class FuncaofuncionarioViewModel
    {
        [Display(Name = "Codigo")]
        [Required]
        [Key]
        //[HiddenInput(DisplayValue = false)]
        public uint Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }
        
    }
}
