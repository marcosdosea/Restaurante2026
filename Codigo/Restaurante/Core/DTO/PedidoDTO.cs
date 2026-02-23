using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PedidoDTO
    {
    public uint Id { get; set; }

    public DateTime DataHoraSolicitacao { get; set; }

    public DateTime DaaHoraAtendimento { get; set; }

    public uint IdAtendimento { get; set; }

    public uint IdGarcom { get; set; }

    /// <summary>
    /// S - SOLICITADO
    /// C - CANCELADO
    /// A - ATENDIDO
    /// </summary>
    public string Status { get; set; } = null!;
    }
}