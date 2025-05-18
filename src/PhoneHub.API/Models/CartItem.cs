namespace PhoneHub.API.Models;

public class CartItem
{
    public int Id { get; set; }
    public int CartId {get; set;}
    public virtual Cart Cart { get; set; } = null!;
}
