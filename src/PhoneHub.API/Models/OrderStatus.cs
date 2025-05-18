namespace PhoneHub.API.Models;

public class OrderStatus
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual List<Order> Orders => [];
}