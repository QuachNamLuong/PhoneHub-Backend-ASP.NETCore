namespace PhoneHub.API.Data.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order {get; set;} = null!;
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}