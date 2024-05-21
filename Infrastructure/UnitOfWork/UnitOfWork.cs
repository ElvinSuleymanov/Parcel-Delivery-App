using Domain;

namespace Infrastructure;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;
    public IAdminRepository Admins { get;set; }
    public ICourierRepository Couriers { get;set; }
    public IOrderRepository Orders { get;set; }
    public IUserRepository Users { get;set; }
    public IProductRepository Products { get ; set ; }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
