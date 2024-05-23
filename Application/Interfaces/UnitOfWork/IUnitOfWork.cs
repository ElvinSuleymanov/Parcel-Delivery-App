namespace Application;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(); 
}
