namespace Models;

public class GetOrderRequest
{
    public int? CourierId { get; set; }
    public int? OrderId { get; set; }   
    public int? UserId { get; set; }
}
