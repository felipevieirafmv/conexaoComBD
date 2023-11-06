using System;
using System.Collections.Generic;

namespace BancoExemplo.Model;

public partial class Vendedor
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Setor { get; set; }

    public DateTime DataNasc { get; set; }

    public virtual ICollection<NotaFiscal> NotaFiscals { get; set; } = new List<NotaFiscal>();
}
