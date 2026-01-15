using System;
using System.Collections.Generic;

namespace Core;

public partial class Tipofuncionario
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}
