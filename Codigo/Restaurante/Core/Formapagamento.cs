using System;
using System.Collections.Generic;

namespace Core;

public partial class Formapagamento
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
