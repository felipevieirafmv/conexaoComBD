using System;
using System.Collections.Generic;

namespace BancoExemplo.Model;

public partial class NotaFiscal
{
    public int Id { get; set; }

    public int Cliente { get; set; }

    public int Produto { get; set; }

    public int Vendedor { get; set; }

    public DateTime DataVenda { get; set; }

    public virtual Cliente ClienteNavigation { get; set; }

    public virtual Produto ProdutoNavigation { get; set; }

    public virtual Vendedor VendedorNavigation { get; set; }
}
