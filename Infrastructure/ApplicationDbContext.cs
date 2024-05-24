using System.Security.Cryptography;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : DbContext(options)
{
    public IConfiguration Configuration { get; set; } = configuration;

    protected override void OnModelCreating( ModelBuilder builder) {
        base.OnModelCreating(builder);
        (byte[], byte[]) PasswordTuple = SeedPasswordGenerator("123");

        builder.Entity<User>().HasData(new User {Id = 1, UserRoleId = 10, Email = "cisco@gmail.com", UserName = "Werner", Salt = PasswordTuple.Item2, Password = PasswordTuple.Item1});
        builder.Entity<Admin>().HasData(new Admin {Id = 1, UserRoleId = 30,Email = "cisco@gmail.com", FullName = "Werner", Salt = PasswordTuple.Item2, Password = PasswordTuple.Item1});
        builder.Entity<Courier>().HasData(new Courier {Id = 1, UserRoleId = 20,Email = "cisco@gmail.com", FullName = "Werner", AdminId = 1, Salt = PasswordTuple.Item2, Password = PasswordTuple.Item1});
        builder.Entity<Product>().HasData(new Product {Id = 1,ProductName = "Macbook Air"}, new Product{Id = 2,ProductName = "Asus rog strix"}, new Product{ Id = 3,ProductName = "RTX 4090"});
        builder.Entity<Order>().HasData(new Order {AdminId = 1, Id = 1, Destination = "Azadliq Avenue", UserId = 1, CourierId = 1, Status = (int)OrderStatus.Pending}, new Order{ Id = 2,AdminId = 1,UserId = 1, Destination = "California, San Francisco", CourierId = 1, Status = (int)OrderStatus.Pending});
        builder.Entity<ProductOrder>().HasData(new ProductOrder{Id = 1, OrderId = 1, ProductId = 1}, new ProductOrder{Id = 2, OrderId = 1, ProductId = 2}, new ProductOrder {Id = 3,OrderId = 2, ProductId = 3});
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=DeliverAppDb;Uid=root;Pwd=elvin;";
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseMySql(connectionString, serverVersion:ServerVersion.AutoDetect(connectionString));
    }
    public (byte[], byte[]) SeedPasswordGenerator(string password) {
        byte[] Salt = SHA256.HashData(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
        byte[] HashedPassword = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        HMACSHA256 hMACSHA256 = new(Salt);
        byte[] Password = hMACSHA256.ComputeHash(HashedPassword);
        return (Password, Salt);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }    
    public DbSet<UserOrder> UserOrders { get; set; }
    public DbSet<Admin> Admins{ get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductOrder> ProductOrders { get; set; }
    public DbSet<Courier> Couriers { get; set; }
}
