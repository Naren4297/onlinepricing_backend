using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using online_pricing_calculator_api.Infrastructure.Data.Entities;

namespace online_pricing_calculator_api.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Discounttype> Discounttypes { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Itemdiscount> Itemdiscounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=online_pricing;Username=sdtt;Password=Password@123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Discountid).HasName("discounts_pkey");

            entity.Property(e => e.Isactive).HasDefaultValue(true);

            entity.HasOne(d => d.Discounttype).WithMany(p => p.Discounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_discount_type");
        });

        modelBuilder.Entity<Discounttype>(entity =>
        {
            entity.HasKey(e => e.Discounttypeid).HasName("discounttypes_pkey");

            entity.Property(e => e.Discounttypeid).ValueGeneratedNever();
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Itemid).HasName("items_pkey");

            entity.Property(e => e.Createdat).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Isactive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Itemdiscount>(entity =>
        {
            entity.HasKey(e => e.Itemdiscountid).HasName("itemdiscounts_pkey");

            entity.HasOne(d => d.Discount).WithMany(p => p.Itemdiscounts).HasConstraintName("fk_discount");

            entity.HasOne(d => d.Item).WithMany(p => p.Itemdiscounts).HasConstraintName("fk_item");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
