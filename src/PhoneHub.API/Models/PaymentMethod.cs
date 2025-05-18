namespace PhoneHub.API.Models;

public class PaymentMethod
{
    public int Id { get; set;}
    public string Name { get; set; } = string.Empty;
    public virtual List<Payment> Payments => [];
}