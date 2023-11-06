using System;
using System.Collections.Generic;

namespace BancoExemplo.Model;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Senha { get; set; }

    public DateTime DataNasc { get; set; }

    public virtual ICollection<NotaFiscal> NotaFiscals { get; set; } = new List<NotaFiscal>();
}
