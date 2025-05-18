namespace PhoneHub.API.Models;

public class Product
{
    public Guid Id { get; init;}
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int? CategoryId { get; set; } = null;
    public virtual Category? Category { get; set; } = null;
}