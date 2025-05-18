namespace PhoneHub.API.Models;

public class OrderStatusHistory
{
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
    public int OrderStatusId { get; set; }
    public virtual OrderStatus OrderStatus { get; set; } = null!;
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}