namespace PhoneHub.API.Data.Entities;

public class PaymentMethod
{
    public int Id { get; set;}
    public string Name { get; set; } = string.Empty;
    public virtual List<Payment> Payments => [];
}