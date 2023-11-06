using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BancoExemplo.Model;

public partial class AulaBdContext : DbContext
{
    public AulaBdContext()
    {
    }

    public AulaBdContext(DbContextOptions<AulaBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<NotaFiscal> NotaFiscals { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Vendedor> Vendedors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-001YQ\\SQLEXPRESS01;Initial Catalog=aulaBD;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC271B2A58C9");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataNasc).HasColumnType("date");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NotaFiscal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC27CFAB4A11");

            entity.ToTable("NotaFiscal");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataVenda).HasColumnType("date");

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.NotaFiscals)
                .HasForeignKey(d => d.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NotaFisca__Clien__3D5E1FD2");

            entity.HasOne(d => d.ProdutoNavigation).WithMany(p => p.NotaFiscals)
                .HasForeignKey(d => d.Produto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NotaFisca__Produ__3E52440B");

            entity.HasOne(d => d.VendedorNavigation).WithMany(p => p.NotaFiscals)
                .HasForeignKey(d => d.Vendedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NotaFisca__Vende__3F466844");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto__3214EC27D3D15376");

            entity.ToTable("Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vendedor__3214EC27E560FF91");

            entity.ToTable("Vendedor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataNasc).HasColumnType("date");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Setor)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
