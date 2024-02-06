using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguerAPI.Model.GoodHamburguer;

public partial class GoodHamburguerContext : DataAccess.GoodHamburguer
{

    public virtual DbSet<Changelog> Changelogs { get; set; }

    public virtual DbSet<LogsApi> LogsApis { get; set; }

    public virtual DbSet<TbItemOrdered> TbItemOrdereds { get; set; }

    public virtual DbSet<TbItemType> TbItemTypes { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Changelog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__changelo__3213E83FDA288D2F");

            entity.ToTable("changelog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Checksum)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("checksum");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.InstalledBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("installed_by");
            entity.Property(e => e.InstalledOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("installed_on");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Success).HasColumnName("success");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("version");
        });

        modelBuilder.Entity<LogsApi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Logs");

            entity.ToTable("Logs_API");

            entity.Property(e => e.Level).HasMaxLength(128);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbItemOrdered>(entity =>
        {
            entity.HasKey(e => e.IdItemOrdered).HasName("PK_id_item_ordered");

            entity.ToTable("tb_item_ordered");

            entity.Property(e => e.IdItemOrdered).HasColumnName("id_item_ordered");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.TbItemOrdereds)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_orders_tb_item_ordered");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.TbItemOrdereds)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_products_tb_item_ordered");
        });

        modelBuilder.Entity<TbItemType>(entity =>
        {
            entity.HasKey(e => e.IdItemType).HasName("PK_id_item_type");

            entity.ToTable("tb_item_type");

            entity.Property(e => e.IdItemType).HasColumnName("id_item_type");
            entity.Property(e => e.ItemTypeName)
                .HasMaxLength(124)
                .IsUnicode(false)
                .HasColumnName("item_type_name");
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK_orders");

            entity.ToTable("tb_orders");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.DateOrder)
                .HasColumnType("datetime")
                .HasColumnName("date_order");
            entity.Property(e => e.TotalPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(9, 4)")
                .HasColumnName("total_price");
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK_id_product");

            entity.ToTable("tb_products");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdItemType).HasColumnName("id_item_type");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(9, 4)")
                .HasColumnName("price");

            entity.HasOne(d => d.IdItemTypeNavigation).WithMany(p => p.TbProducts)
                .HasForeignKey(d => d.IdItemType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_item_type_tb_products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
