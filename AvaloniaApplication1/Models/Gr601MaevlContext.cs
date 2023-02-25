using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.Models;

public partial class Gr601MaevlContext : DbContext
{
    public Gr601MaevlContext()
    {
    }

    public Gr601MaevlContext(DbContextOptions<Gr601MaevlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buy> Buys { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=10.30.0.137;Port=5432;Database=gr601_maevl;Username=gr601_maevl;Password=RSUiamRSUiam");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Buy_pk");

            entity.ToTable("Buy");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.TypePayment)
                .HasColumnType("character varying")
                .HasColumnName("type_payment");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Buys)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("Buy_Clients_null_fk");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Buys)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("Buy_Product_null_fk");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Clients_pk");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DataPassport)
                .HasColumnType("character varying")
                .HasColumnName("data_passport");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.HomeAddress)
                .HasColumnType("character varying")
                .HasColumnName("home_address");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Product_pk");

            entity.ToTable("Product");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasColumnType("character varying")
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasColumnType("character varying")
                .HasColumnName("color");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Country)
                .HasColumnType("character varying")
                .HasColumnName("country");
            entity.Property(e => e.Model)
                .HasColumnType("character varying")
                .HasColumnName("model");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
