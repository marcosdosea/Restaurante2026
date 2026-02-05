using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestauranteWeb.Models
{
    public class FuncionarioViewModel
    {
        public uint Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cpf { get; set; } = string.Empty;

        [Display(Name = "Restaurante")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint IdRestaurante { get; set; }

        public string? NomeRestaurante { get; set; }

        [Display(Name = "Função")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public uint IdFuncaoFuncionario { get; set; }

        public string? NomeFuncao { get; set; }

        public SelectList? ListaFuncoes { get; set; }
        public SelectList? ListaRestaurantes { get; set; }
    }
}