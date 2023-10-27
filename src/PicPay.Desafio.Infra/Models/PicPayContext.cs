using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PicPay.Desafio.Infra.Models;

public partial class PicPayContext : DbContext
{
    public PicPayContext()
    {
    }

    public PicPayContext(DbContextOptions<PicPayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Transacao> Transacoes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,2727;Initial Catalog=PicPay;TrustServerCertificate=true;Persist Security Info=True;User ID=sa;Password=12345qwerASDF;Pooling=True;Max Pool Size=200;Min Pool Size=5;Connection Timeout=90");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.HasKey(e => e.IdTransacao).HasName("PK__Transaca__0FBBF773B9D68BBD");

            entity.ToTable("Transacao");

            entity.Property(e => e.IdTransacao).HasColumnName("id_transacao");
            entity.Property(e => e.DataTransacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("data_transacao");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Moeda)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("moeda");
            entity.Property(e => e.Quantia)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("quantia");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TipoOperacao).HasColumnName("tipo_operacao");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Transacaos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transacao_on_usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__3213E83F9EFF56D3");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__AB6E616425F0B4A9").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Documento)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("documento");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome_completo");
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("senha");
            entity.Property(e => e.Tipo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
