using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria001.Models
{
    public partial class PizzeriaContext : DbContext
    {
        public PizzeriaContext()
        {
        }

        public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<NonvegPizza> NonvegPizzas { get; set; } = null!;
        public virtual DbSet<OrderPizza> OrderPizzas { get; set; } = null!;
        public virtual DbSet<Pizza> Pizzas { get; set; } = null!;
        public virtual DbSet<PizzaReview> PizzaReviews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VegPizza> VegPizzas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local); Initial Catalog=Pizzeria; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.Cartid).HasColumnName("cartid");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<NonvegPizza>(entity =>
            {
                entity.HasKey(e => e.Nvegid);

                entity.ToTable("nonvegPizza");

                entity.Property(e => e.Nvegid).HasColumnName("nvegid");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<OrderPizza>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__order_pi__0809335D2F52649C");

                entity.ToTable("order_pizza");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.OrderNumber).HasColumnName("orderNumber");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .HasColumnName("payment_method");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("totalAmount");

                entity.Property(e => e.Usersid).HasColumnName("usersid");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.OrderPizzas)
                    .HasForeignKey(d => d.Usersid)
                    .HasConstraintName("FK__order_piz__users__2F10007B");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("pizza");

                entity.Property(e => e.Pizzaid).HasColumnName("pizzaid");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__pizza__categoryI__286302EC");
            });

            modelBuilder.Entity<PizzaReview>(entity =>
            {
                entity.HasKey(e => e.Reviewid);

                entity.ToTable("pizzaReview");

                entity.Property(e => e.Reviewid).HasColumnName("reviewid");

                entity.Property(e => e.Pizzaname)
                    .HasMaxLength(50)
                    .HasColumnName("pizzaname");

                entity.Property(e => e.Review).HasColumnName("review");

                entity.Property(e => e.Stars).HasColumnName("stars");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Usersid)
                    .HasName("PK__users__788CD93DE63ABD69");

                entity.ToTable("users");

                entity.Property(e => e.Usersid).HasColumnName("usersid");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Usersrole)
                    .HasMaxLength(50)
                    .HasColumnName("usersrole")
                    .HasDefaultValueSql("('user')");
            });

            modelBuilder.Entity<VegPizza>(entity =>
            {
                entity.ToTable("vegPizza");

                entity.Property(e => e.Vegpizzaid).HasColumnName("vegpizzaid");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
