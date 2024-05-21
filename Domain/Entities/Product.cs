namespace Domain;

public class Product:Entity
{
    public string ProductName { get; set; }
    public ICollection<ProductOrder> Orders { get; set;}   
}
