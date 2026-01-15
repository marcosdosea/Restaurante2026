using System;
using System.Collections.Generic;

namespace Core;

public partial class Tiporestaurante
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Restaurante> Restaurantes { get; set; } = new List<Restaurante>();
}
