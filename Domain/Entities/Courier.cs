namespace Domain;

public class Courier:Entity
{
    public int UserRoleId { get; set;} = (int)Roles.Courier;
    public int AdminId {get;set;}
    public ICollection<Order> Orders { get; set; }  
}