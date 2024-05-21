namespace Domain;

public class Order:Entity
{
    public string Destination { get; set; } 
    public int UserId { get; set; }
    public int CourierId { get; set; }
    public ICollection<ProductOrder> ProductOrders { get; set; }
    public int Status { get; set; } = (int)OrderStatus.Pending;
    public void Delivered() {
       Status = (int)OrderStatus.Delivered;
    }
    public void Shipped() {
        Status = (int)OrderStatus.Shipped;
    }
}
