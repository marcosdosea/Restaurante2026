using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWeb.Models
{
    public class TiporestauranteViewModel
    {
        [Key]
        [Required (ErrorMessage = "O campo Id é obrigatório.")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo Nome deve ter no máximo 30 caracteres.")]
        public string Nome { get; set; } = null!;
    }
}