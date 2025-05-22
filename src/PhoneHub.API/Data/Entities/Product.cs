namespace PhoneHub.API.Data.Entities;

public class Product
{
    public int Id { get; init;}
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int? CategoryId { get; set; } = null;
    public virtual Category? Category { get; set; } = null;
}