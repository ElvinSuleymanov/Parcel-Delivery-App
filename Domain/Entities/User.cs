namespace Domain;

public class User:Entity
{
    public string UserName { get; set;}
    public string Email { get; set;}
    public byte[]? Password { get; set;} 
    public byte[]? Salt { get; set;}
    public int UserRoleId { get; set;} = (int)Roles.User;
    public ICollection<Order> Orders { get; set;}
}
