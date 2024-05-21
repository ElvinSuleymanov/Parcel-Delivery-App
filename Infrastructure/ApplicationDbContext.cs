using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : DbContext(options)
{
    public IConfiguration Configuration { get; set; } = configuration;

    protected override void OnModelCreating( ModelBuilder builder) {
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=DeliverAppDb;Uid=root;Pwd=elvin;";
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseMySql(connectionString, serverVersion:ServerVersion.AutoDetect(connectionString));
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }    
    public DbSet<UserOrder> UserOrders { get; set; }
    public DbSet<Admin> Admins{ get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductOrder> ProductOrders { get; set; }
    public DbSet<Courier> Couriers { get; set; }
}
