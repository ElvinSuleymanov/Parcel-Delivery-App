namespace Domain;

public class Admin:Entity
{
    public string FullName {get;set;}
    public string Email {get;set;}  
    public byte[] Password {get;set;}   
    public byte[] Salt {get;set;} 
    public ICollection<Courier> Couriers {get;set;}
    public ICollection<Order> Orders {get;set;}
    public int UserRoleId { get; set;} = (int)Roles.Admin;

}
