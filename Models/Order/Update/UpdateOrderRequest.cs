namespace Models;

public class UpdateOrderRequest
{
    public int CourierId { get; set; }
    public int OrderId { get; set; }    
    public int OrderStatus { get; set; }
}
