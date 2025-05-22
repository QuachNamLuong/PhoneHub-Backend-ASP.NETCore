namespace PhoneHub.API.Data.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual List<OrderItem> OrderItems => [];
}