using System;
using System.Collections.Generic;

namespace BancoExemplo.Model;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public double Valor { get; set; }

    public virtual ICollection<NotaFiscal> NotaFiscals { get; set; } = new List<NotaFiscal>();
}
