using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace coursework01.Models;

public partial class CarSalesCenterContext : DbContext
{
    public CarSalesCenterContext()
    {
    }

    public CarSalesCenterContext(DbContextOptions<CarSalesCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarModel> CarModels { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=car_sales_center; Username=postgres; Password=130281");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cars_pkey");

            entity.ToTable("cars");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarModel).HasColumnName("car_model");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("image");
            entity.Property(e => e.Mileage).HasColumnName("mileage");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Vin)
                .HasMaxLength(17)
                .IsFixedLength()
                .HasColumnName("vin");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.CarModelNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarModel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cars_car_model_fkey");
        });

        modelBuilder.Entity<CarModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("car_models_pkey");

            entity.ToTable("car_models");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BodyType)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("body_type");
            entity.Property(e => e.EngineType)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasColumnName("engine_type");
            entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");

            entity.HasOne(d => d.ManufacturerNavigation).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.Manufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("car_models_manufacturer_fkey");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customers_pkey");

            entity.ToTable("customers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("first_name");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("login");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("middle_name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("first_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("middle_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("phone_number");
            entity.Property(e => e.Position)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("position");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("manufacturers_pkey");

            entity.ToTable("manufacturers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.HotlinePhoneNumber)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("hotline_phone_number");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Website)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("website");
        });

        modelBuilder.Entity<PurchaseRequisition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purchase_requisitions_pkey");

            entity.ToTable("purchase_requisitions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Car).HasColumnName("car");
            entity.Property(e => e.Customer).HasColumnName("customer");

            entity.HasOne(d => d.CarNavigation).WithMany(p => p.PurchaseRequisitions)
                .HasForeignKey(d => d.Car)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("purchase_requisitions_car_fkey");

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.PurchaseRequisitions)
                .HasForeignKey(d => d.Customer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("purchase_requisitions_customer_fkey");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sales_pkey");

            entity.ToTable("sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Car).HasColumnName("car");
            entity.Property(e => e.Commission).HasColumnName("commission");
            entity.Property(e => e.Customer).HasColumnName("customer");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(9)
                .IsFixedLength()
                .HasColumnName("payment_method");
            entity.Property(e => e.SaleDate).HasColumnName("sale_date");
            entity.Property(e => e.SalePrice).HasColumnName("sale_price");

            entity.HasOne(d => d.CarNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Car)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales_car_fkey");

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Customer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales_customer_fkey");

            entity.HasOne(d => d.EmployeeNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Employee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales_employee_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
