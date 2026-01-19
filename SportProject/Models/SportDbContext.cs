using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SportProject.Models;

public partial class SportDbContext : DbContext
{
    public SportDbContext()
    {
    }

    public SportDbContext(DbContextOptions<SportDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersComposition> OrdersCompositions { get; set; }

    public virtual DbSet<PickupPoint> PickupPoints { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Tovar> Tovars { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sport_db;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_categories_id");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName).HasColumnName("category_name");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_goods_id");

            entity.ToTable("goods");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GoodName).HasColumnName("good_name");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_manufacturers_id");

            entity.ToTable("manufacturers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ManufacturerName).HasColumnName("manufacturer_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_orders_id");

            entity.ToTable("orders");

            entity.HasIndex(e => e.Code, "uq_orders_code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DateDelivery).HasColumnName("date_delivery");
            entity.Property(e => e.DateOrder).HasColumnName("date_order");
            entity.Property(e => e.IdPickupPoint).HasColumnName("id_pickup_point");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("fk_orders_to_statuses");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_orders_to_users");
        });

        modelBuilder.Entity<OrdersComposition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_orders_composition_id");

            entity.ToTable("orders_composition");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdArticle).HasColumnName("id_article");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Tovar).WithMany(p => p.OrdersCompositions)
                .HasForeignKey(d => d.IdArticle)
                .HasConstraintName("fk_orders_composition_to_tovars");

            entity.HasOne(d => d.Order).WithMany(p => p.OrdersCompositions)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("fk_orders_composition_to_orders");
        });

        modelBuilder.Entity<PickupPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_pickup_points_id");

            entity.ToTable("pickup_points");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.NumberHouse).HasColumnName("number_house");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(20)
                .HasColumnName("number_phone");
            entity.Property(e => e.Street).HasColumnName("street");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_roles_id");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_statuses_id");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("status_name");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_suppliers_id");

            entity.ToTable("suppliers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SupplierName).HasColumnName("supplier_name");
        });

        modelBuilder.Entity<Tovar>(entity =>
        {
            entity.HasKey(e => e.Article).HasName("pk_tovars_article");

            entity.ToTable("tovars");

            entity.Property(e => e.Article).HasColumnName("article");
            entity.Property(e => e.CountTovars).HasColumnName("count_tovars");
            entity.Property(e => e.Descreption).HasColumnName("descreption");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.IdTovar).HasColumnName("id_tovar");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Unit).HasColumnName("unit");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("fk_tovars_to_categories");

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.IdManufacturer)
                .HasConstraintName("fk_tovars_to_manufacturers");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.IdSupplier)
                .HasConstraintName("fk_tovars_to_suppliers");

            entity.HasOne(d => d.IdTovarNavigation).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.IdTovar)
                .HasConstraintName("fk_tovars_to_goods");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users_id");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "uq_users_login").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fio).HasColumnName("fio");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.PasswordUser).HasColumnName("password_user");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("fk_users_to_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
