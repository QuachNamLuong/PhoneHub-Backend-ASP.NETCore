namespace PhoneHub.API.Data.Entities;

public class Payment
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
    public int PaymentMethodId { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}