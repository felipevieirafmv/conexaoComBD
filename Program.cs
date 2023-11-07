using System;
using System.Linq;
using System.Threading.Tasks;

using BancoExemplo.Model;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

AulaBdContext context = new AulaBdContext();

// await createCliente("Dom", "Dom");
// await createProduto("Bico Injetor", 4.5);
// await createVendedor("Balem", "ETS");

var clients =
    from client in context.Clientes
    where client.Nome == "Donathan"
    select client;

var dom = clients.FirstOrDefault();

var products =
    from product in context.Produtos
    where product.Nome == "Bico Injetor"
    select product;

var bicoInjetor = products.FirstOrDefault();

var sellers = 
    from seller in context.Vendedors
    where seller.Nome == "Balem"
    select seller;

var balem = sellers.FirstOrDefault();

// await createNotaFiscal(dom, bicoInjetor, balem);

// await updateCliente(dom, "Donathan", "");
// await deleteCliente(dom);

searchByClient(dom);

void searchByClient(Cliente cliente)
{
    var query =
        from client in context.Clientes
        where client.Nome == cliente.Nome
        join notaFiscal in context.NotaFiscals
        on client.Id equals notaFiscal.Cliente
        select new {
            nome = client.Nome,
            produtoId = notaFiscal.Produto,
            vendedorId = notaFiscal.Vendedor,
        } into x
        join produto in context.Produtos
        on x.produtoId equals produto.Id
        join vendedor in context.Vendedors
        on x.vendedorId equals vendedor.Id
        select new {
            nomeCliente = x.nome,
            nomeVendedor = vendedor.Nome,
            nomeProduto = produto.Nome
        };
        foreach (var y in query)
            Console.WriteLine($"{y.nomeCliente} comprou um {y.nomeProduto} com o vendedor {y.nomeVendedor}.");
}

async Task createCliente(string nome, string senha)
{
    Cliente cliente = new Cliente();
    cliente.Nome = nome;
    cliente.Senha = senha;
    cliente.DataNasc = DateTime.Now;

    //É igual as 4 linhas de cima
    // Cliente cliente = new Cliente
    // {
    //     Nome = nome,
    //     Senha = senha,
    //     DataNasc = DateTime.Now
    // };

    context.Clientes.Add(cliente);
    await context.SaveChangesAsync();
}

async Task createProduto(string nome, double valor)
{
    Produto produto = new Produto();
    produto.Nome = nome;
    produto.Valor = valor;

    context.Produtos.Add(produto);
    await context.SaveChangesAsync();
}

async Task createVendedor(string nome, string setor)
{
    Vendedor vendedor = new Vendedor();
    vendedor.Nome = nome;
    vendedor.Setor = setor;
    vendedor.DataNasc = DateTime.Now;

    context.Vendedors.Add(vendedor);
    await context.SaveChangesAsync();
}

async Task createNotaFiscal(Cliente cliente, Produto produto, Vendedor vendedor)
{
    NotaFiscal notaFiscal = new NotaFiscal();
    notaFiscal.Cliente = cliente.Id;
    notaFiscal.Produto = produto.Id;
    notaFiscal.Vendedor = vendedor.Id;
    notaFiscal.DataVenda = DateTime.Now;

    context.NotaFiscals.Add(notaFiscal);
    await context.SaveChangesAsync();
}

async Task updateCliente(Cliente cliente, string nome, string senha)
{
    if(nome != "")
        cliente.Nome = nome;
    if(senha != "")
        cliente.Senha = senha;
    await context.SaveChangesAsync();
}

async Task deleteCliente(Cliente cliente)
{
    context.Clientes.Remove(cliente);
    await context.SaveChangesAsync();
}

async Task deleteProduto(Produto produto)
{
    context.Produtos.Remove(produto);
    await context.SaveChangesAsync();
}