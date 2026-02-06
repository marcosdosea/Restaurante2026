using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class FuncionarioDTO
    {
        public uint Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string Cpf { get; set; } = string.Empty;

        [Display(Name = "Restaurante")]
        [Required(ErrorMessage = "O restaurante é obrigatório")]
        public uint IdRestaurante { get; set; }

        public string? NomeRestaurante { get; set; }

        [Display(Name = "Função")]
        [Required(ErrorMessage = "A função é obrigatória")]
        public uint IdFuncaoFuncionario { get; set; }

        public string? NomeFuncao { get; set; }
    }
}