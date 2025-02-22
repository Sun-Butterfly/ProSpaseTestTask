using Microsoft.EntityFrameworkCore;
using ProSpaceTestTask.Models;

namespace ProSpaceTestTask;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderElement> OrderElements { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;

    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(x => x.RoleId);

        modelBuilder.Entity<Role>()
            .Property(x => x.Name)
            .HasConversion<string>();

        modelBuilder.Entity<Role>()
            .HasData(new List<Role>()
            {
                new Role()
                {
                    Id = 1,
                    Name = "administrator"
                },
                new Role()
                {
                    Id = 2,
                    Name = "customer"
                }
            });

        modelBuilder.Entity<Customer>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Customer>()
            .HasOne(x => x.User)
            .WithOne(y => y.Customer)
            .HasForeignKey<Customer>(z => z.Id);

        modelBuilder.Entity<Order>()
            .HasOne(x => x.Customer)
            .WithMany(y => y.Orders)
            .HasForeignKey(z => z.CustomerId);

        modelBuilder.Entity<OrderElement>()
            .HasOne(x => x.Order)
            .WithMany(y => y.OrderElements)
            .HasForeignKey(z => z.OrderId);

        modelBuilder.Entity<OrderElement>()
            .HasOne(x => x.Item)
            .WithMany(y => y.OrderElements)
            .HasForeignKey(z => z.ItemId);

        modelBuilder.Entity<Cart>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<Cart>()
            .HasOne(x => x.Customer)
            .WithOne(x => x.Cart)
            .HasForeignKey<Cart>(x => x.Id);

        modelBuilder.Entity<CartItem>()
            .HasOne(x => x.Cart)
            .WithMany(x => x.CartItems)
            .HasForeignKey(x => x.CartId);

        modelBuilder.Entity<CartItem>()
            .HasOne(x => x.Item)
            .WithMany(x => x.CartItems)
            .HasForeignKey(x => x.ItemId);
    }
}