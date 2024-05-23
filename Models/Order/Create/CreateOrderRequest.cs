namespace Models;

public class CreateOrderRequest
{
    public int UserId { get; set; }
    public List<int> ProductId { get; set; }
    public int AdminId { get; set; }
    public string Destination { get; set; } 
    
}
