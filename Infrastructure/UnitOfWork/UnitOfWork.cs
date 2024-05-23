using Application;

namespace Infrastructure;

public class UnitOfWork(ApplicationDbContext applicationDbContext) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = applicationDbContext;
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
