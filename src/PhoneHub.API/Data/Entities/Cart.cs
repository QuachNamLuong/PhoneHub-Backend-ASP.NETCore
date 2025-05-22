namespace PhoneHub.API.Data.Entities;

public class Cart
{
    public int Id { get; set; }
    public int UserId {get; set;}
    public virtual List<CartItem> CartItems => [];
}