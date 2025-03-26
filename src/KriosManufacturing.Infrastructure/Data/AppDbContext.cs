namespace KriosManufacturing.Infrastructure.Data;

using Core.Models;

using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Item>? Items
    {
        get;
        set;
    }

    public DbSet<Location>? Locations
    {
        get;
        set;
    }

    public DbSet<InventoryRecord>? InventoryRecords
    {
        get;
        set;
    }

    public DbSet<Lot>? Lots
    {
        get;
        set;
    }

    public DbSet<Order>? Orders
    {
        get;
        set;
    }

    public DbSet<OrderDetail>? OrderDetails
    {
        get;
        set;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null) return;

        modelBuilder.Entity<Lot>(lot =>
        {
            lot.HasKey(l => l.Id);
            lot.HasIndex(l => l.LotNumber)
                .IsUnique();
        });

        modelBuilder.Entity<Location>(location =>
        {
            location.HasKey(loc => loc.Id);
            location.HasIndex(loc => new { loc.Unit, loc.Cell })
                .IsUnique();
        });

        modelBuilder.Entity<Item>(item =>
        {
            item.HasKey(it => it.Id);
            item.HasIndex(it => it.Sku)
                .IsUnique();
        });

        modelBuilder.Entity<InventoryRecord>(inventoryRecord =>
            {
                inventoryRecord.HasKey(ir => ir.Id);
            });
        modelBuilder.Entity<InventoryRecord>()
            .ToTable(t => t.HasCheckConstraint("CK_Quantity", "\"Quantity\" > 0"));

        modelBuilder.Entity<Order>(order =>
        {
            order.HasKey(o => o.Id);
            order.HasIndex(o => o.OrderNumber)
                .IsUnique();
            order.Property(o => o.OrderNumber)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<OrderDetail>(od =>
        {
            od.HasKey(o => o.Id);
        });
        modelBuilder.Entity<OrderDetail>().ToTable(t => t.HasCheckConstraint("CK_Quantity", "\"Quantity\" > 0"));
    }
}