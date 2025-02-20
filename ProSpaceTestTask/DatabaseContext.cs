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

        modelBuilder.Entity<User>()
            .HasOne(x => x.Customer)
            .WithOne(y => y.User)
            .HasForeignKey<User>(z => z.CustomerId);

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
    }
}