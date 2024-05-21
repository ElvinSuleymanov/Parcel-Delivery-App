namespace Domain;

public interface IUnitOfWork
{
    public IAdminRepository Admins { get; set; }  
    public ICourierRepository Couriers {get;set;} 
    public IOrderRepository Orders { get; set; }
    public IUserRepository Users { get; set; }
    public IProductRepository Products { get; set; }
    public Task SaveChangesAsync(); 
}
