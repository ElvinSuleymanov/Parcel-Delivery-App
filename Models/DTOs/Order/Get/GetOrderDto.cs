using Domain;

namespace Models;

public class GetOrderDto
{
    public int Id { get; set;}  
    public string Destination { get; set; } 
    public int UserId { get; set; }
    public int? CourierId { get; set; }
    public int Status { get; set; } = (int)OrderStatus.Pending;
    public List<Product> Products { get; set; }
}   
