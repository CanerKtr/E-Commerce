using ECommerceProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
namespace ECommerceProjectAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BookProduct> Books { get; set; }
        public DbSet<PhoneProduct> Phones { get; set; }
        public DbSet<LaptopProduct> Laptops { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee self-referencing Relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Supervisor)
                .WithMany(s => s.SupervisorOf)
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict); // Before delete supervisor, you have to assign the subordinates to another supervisor 
            // Employee many to one Branch Relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Branch)
                .WithMany(b => b.Employees)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.SetNull);
            // Employee one to many Product Relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.TrackingBy)
                .WithMany(e => e.TrackedProducts)
                .HasForeignKey(p => p.SalesPersonId)
                .OnDelete(DeleteBehavior.SetNull);
            // Branch one to many Employee Relationship
            modelBuilder.Entity<Branch>()
                .HasOne(b => b.Manager)
                .WithMany(m => m.ManagedBranches)
                .HasForeignKey(b => b.MgrId)
                .OnDelete(DeleteBehavior.Restrict);
            // Customer one to one Cart Relationship
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Cart)
                .WithOne(ca => ca.Customer)
                .HasForeignKey<Cart>(ca => ca.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            // Customer one to many Orders Relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            // Cart one to many CartItems Relationship
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);
            // Product one to many OrderItems Relationship
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            // Product one to many CartItems Relationship
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            // Order one to many OrderItems Relationship
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            // User one to many Adress Relationship
            modelBuilder.Entity<Address>()
                .HasOne(o => o.User)
                .WithMany(p => p.Addresses)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            // Address one to one Order Relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithOne(a => a.Order)
                .HasForeignKey<Order>(o => o.AddressId)
                .OnDelete(DeleteBehavior.NoAction);



            // Configure TPT Inheritance -----

            modelBuilder.Entity<Product>()
                .ToTable("Products"); 

            modelBuilder.Entity<PhoneProduct>()
                .ToTable("Phones");

            modelBuilder.Entity<BookProduct>()
                .ToTable("Books");

            modelBuilder.Entity<LaptopProduct>()
                .ToTable("Laptops");

            //-------------------------------------

            // ------------ USER TPT --------------
            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<Customer>()
                .ToTable("Customers");

            modelBuilder.Entity<Employee>()
                .ToTable("Employees");

            modelBuilder.Entity<Admin>()
                .ToTable("Admins");

            // enum to string conversion for all enums in the model

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var enumProps = entityType.ClrType
                    .GetProperties()
                    .Where(p => p.PropertyType.IsEnum);

                foreach (var prop in enumProps)
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property(prop.Name)
                        .HasConversion<string>();
                }
            }

        }
    }
}
