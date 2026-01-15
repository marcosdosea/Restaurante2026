using System;
using System.Collections.Generic;

namespace Core;

public partial class Pagamento
{
    public uint Id { get; set; }

    public DateTime DataHora { get; set; }

    public decimal Valor { get; set; }

    public uint IdAtendimento { get; set; }

    public uint IdFormaPagamento { get; set; }

    public virtual Atendimento IdAtendimentoNavigation { get; set; } = null!;

    public virtual Formapagamento IdFormaPagamentoNavigation { get; set; } = null!;
}
