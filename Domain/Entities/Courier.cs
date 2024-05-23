namespace Domain;

public class Courier:Entity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public byte[] Password  { get; set; }  
    public byte[] Salt { get; set; }    
    public int UserRoleId { get; set;} = (int)Roles.Courier;
    public int AdminId {get;set;}
    public ICollection<Order> Orders { get; set; }  
}