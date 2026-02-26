using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace Core.DTO
{
    public class PedidoDTO
    {
        [Key]
        [Display(Name = "ID do Pedido")]
        public uint Id { get; set; }

        [Display(Name = "Data e Hora da Solicitação")]
        [Required(ErrorMessage = "A data e hora da solicitação são obrigatórias")]
        public DateTime DataHoraSolicitacao { get; set; }

        [Display(Name = "Data e Hora do Atendimento")]
        [Required(ErrorMessage = "A data e hora do atendimento são obrigatórias")]
        public DateTime DaaHoraAtendimento { get; set; }

        [Display(Name = "Atendimento")]
        [Required(ErrorMessage = "O atendimento é obrigatório")]
        public uint IdAtendimento { get; set; }

        [Display(Name = "Garçom")]
        [Required(ErrorMessage = "O garçom é obrigatório")]
        public uint IdGarcom { get; set; }

        [Display(Name = "Status do Pedido")]
        [Required(ErrorMessage = "O status do pedido é obrigatório")]
        public string Status { get; set; } = null!;
    }
}