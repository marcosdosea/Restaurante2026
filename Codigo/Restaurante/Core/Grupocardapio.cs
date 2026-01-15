using System;
using System.Collections.Generic;

namespace Core;

public partial class Grupocardapio
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Itemcardapio> Itemcardapios { get; set; } = new List<Itemcardapio>();
}
