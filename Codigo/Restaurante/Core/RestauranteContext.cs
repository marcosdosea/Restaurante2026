using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class RestauranteContext : DbContext
{
    public RestauranteContext()
    {
    }

    public RestauranteContext(DbContextOptions<RestauranteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atendimento> Atendimentos { get; set; }

    public virtual DbSet<Formapagamento> Formapagamentos { get; set; }

    public virtual DbSet<Funcaofuncionario> Funcaofuncionarios { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Grupocardapio> Grupocardapios { get; set; }

    public virtual DbSet<Itemcardapio> Itemcardapios { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Pedidoitemcardapio> Pedidoitemcardapios { get; set; }

    public virtual DbSet<Restaurante> Restaurantes { get; set; }

    public virtual DbSet<Tiporestaurante> Tiporestaurantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atendimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("atendimento");

            entity.HasIndex(e => e.IdMesa, "fk_Atendimento_mesa1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataHoraFim)
                .HasColumnType("datetime")
                .HasColumnName("dataHoraFim");
            entity.Property(e => e.DataHoraInicio)
                .HasColumnType("datetime")
                .HasColumnName("dataHoraInicio");
            entity.Property(e => e.IdMesa).HasColumnName("idMesa");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'I'")
                .HasComment("I - INICIADO\nC- CANCELADO\nF - FINALIZADO\n")
                .HasColumnType("enum('I','C','F')")
                .HasColumnName("status");
            entity.Property(e => e.Total)
                .HasPrecision(10)
                .HasColumnName("total");
            entity.Property(e => e.TotalConta)
                .HasPrecision(10)
                .HasColumnName("totalConta");
            entity.Property(e => e.TotalDesconto)
                .HasPrecision(10)
                .HasColumnName("totalDesconto");
            entity.Property(e => e.TotalServico)
                .HasPrecision(10)
                .HasColumnName("totalServico");

            entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.IdMesa)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Atendimento_mesa1");
        });

        modelBuilder.Entity<Formapagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("formapagamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Funcaofuncionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("funcaofuncionario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("funcionario");

            entity.HasIndex(e => e.IdFuncaoFuncionario, "fk_Funcionario_TipoFuncionario1_idx");

            entity.HasIndex(e => e.IdRestaurante, "fk_garcom_restaurante1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(45)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(45)
                .HasColumnName("cidade");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.IdFuncaoFuncionario).HasColumnName("idFuncaoFuncionario");
            entity.Property(e => e.IdRestaurante).HasColumnName("idRestaurante");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Rua)
                .HasMaxLength(45)
                .HasColumnName("rua");
            entity.Property(e => e.Telefone1)
                .HasMaxLength(11)
                .HasColumnName("telefone1");
            entity.Property(e => e.Telefone2)
                .HasMaxLength(11)
                .HasColumnName("telefone2");

            entity.HasOne(d => d.IdFuncaoFuncionarioNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdFuncaoFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Funcionario_TipoFuncionario1");

            entity.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdRestaurante)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_garcom_restaurante1");
        });

        modelBuilder.Entity<Grupocardapio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("grupocardapio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Itemcardapio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("itemcardapio");

            entity.HasIndex(e => e.IdGrupoCardapio, "fk_itemcardapio_GrupoCardapio1_idx");

            entity.HasIndex(e => e.IdRestaurante, "fk_itemcardapio_restaurante1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("ativo");
            entity.Property(e => e.Detalhes)
                .HasMaxLength(500)
                .HasColumnName("detalhes");
            entity.Property(e => e.IdGrupoCardapio).HasColumnName("idGrupoCardapio");
            entity.Property(e => e.IdRestaurante).HasColumnName("idRestaurante");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Preco)
                .HasPrecision(10)
                .HasColumnName("preco");

            entity.HasOne(d => d.IdGrupoCardapioNavigation).WithMany(p => p.Itemcardapios)
                .HasForeignKey(d => d.IdGrupoCardapio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_itemcardapio_GrupoCardapio1");

            entity.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Itemcardapios)
                .HasForeignKey(d => d.IdRestaurante)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_itemcardapio_restaurante1");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mesa");

            entity.HasIndex(e => e.IdRestaurante, "fk_mesa_restaurante_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdRestaurante).HasColumnName("idRestaurante");
            entity.Property(e => e.Identificacao)
                .HasMaxLength(45)
                .HasColumnName("identificacao");

            entity.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.IdRestaurante)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_mesa_restaurante");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pagamento");

            entity.HasIndex(e => e.IdAtendimento, "fk_Pagamento_Atendimento1_idx");

            entity.HasIndex(e => e.IdFormaPagamento, "fk_Pagamento_FormaPagamento1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataHora)
                .HasColumnType("datetime")
                .HasColumnName("dataHora");
            entity.Property(e => e.IdAtendimento).HasColumnName("idAtendimento");
            entity.Property(e => e.IdFormaPagamento).HasColumnName("idFormaPagamento");
            entity.Property(e => e.Valor)
                .HasPrecision(10)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdAtendimentoNavigation).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.IdAtendimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pagamento_Atendimento1");

            entity.HasOne(d => d.IdFormaPagamentoNavigation).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.IdFormaPagamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pagamento_FormaPagamento1");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pedido");

            entity.HasIndex(e => e.IdAtendimento, "fk_Pedido_Atendimento1_idx");

            entity.HasIndex(e => e.IdGarcom, "fk_Pedido_garcom1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DaaHoraAtendimento)
                .HasColumnType("datetime")
                .HasColumnName("daaHoraAtendimento");
            entity.Property(e => e.DataHoraSolicitacao)
                .HasColumnType("datetime")
                .HasColumnName("dataHoraSolicitacao");
            entity.Property(e => e.IdAtendimento).HasColumnName("idAtendimento");
            entity.Property(e => e.IdGarcom).HasColumnName("idGarcom");
            entity.Property(e => e.Status)
                .HasComment("S - SOLICITADO\nC - CANCELADO\nA - ATENDIDO")
                .HasColumnType("enum('S','C','A')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdAtendimentoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdAtendimento)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Pedido_Atendimento1");

            entity.HasOne(d => d.IdGarcomNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdGarcom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pedido_garcom1");
        });

        modelBuilder.Entity<Pedidoitemcardapio>(entity =>
        {
            entity.HasKey(e => new { e.IdItemCardapio, e.IdPedido }).HasName("PRIMARY");

            entity.ToTable("pedidoitemcardapio");

            entity.HasIndex(e => e.IdPedido, "fk_itemcardapio_has_Pedido_Pedido1_idx");

            entity.HasIndex(e => e.IdItemCardapio, "fk_itemcardapio_has_Pedido_itemcardapio1_idx");

            entity.Property(e => e.IdItemCardapio).HasColumnName("idItemCardapio");
            entity.Property(e => e.IdPedido).HasColumnName("idPedido");
            entity.Property(e => e.Quantidade)
                .HasPrecision(10)
                .HasColumnName("quantidade");

            entity.HasOne(d => d.IdItemCardapioNavigation).WithMany(p => p.Pedidoitemcardapios)
                .HasForeignKey(d => d.IdItemCardapio)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_itemcardapio_has_Pedido_itemcardapio1");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Pedidoitemcardapios)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_itemcardapio_has_Pedido_Pedido1");
        });

        modelBuilder.Entity<Restaurante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("restaurante");

            entity.HasIndex(e => e.IdTipoRestaurante, "fk_restaurante_TipoRestaurante1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(45)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(45)
                .HasColumnName("cidade");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(15)
                .HasColumnName("cnpj");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.IdTipoRestaurante).HasColumnName("idTipoRestaurante");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .HasColumnName("nome");
            entity.Property(e => e.Rua)
                .HasMaxLength(45)
                .HasColumnName("rua");
            entity.Property(e => e.Telefone1)
                .HasMaxLength(14)
                .HasColumnName("telefone1");
            entity.Property(e => e.Telefone2)
                .HasMaxLength(14)
                .HasColumnName("telefone2");

            entity.HasOne(d => d.IdTipoRestauranteNavigation).WithMany(p => p.Restaurantes)
                .HasForeignKey(d => d.IdTipoRestaurante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_restaurante_TipoRestaurante1");
        });

        modelBuilder.Entity<Tiporestaurante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tiporestaurante");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
