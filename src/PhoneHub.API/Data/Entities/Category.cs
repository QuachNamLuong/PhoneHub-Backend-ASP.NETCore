namespace PhoneHub.API.Data.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual List<Product> Products => [];
}