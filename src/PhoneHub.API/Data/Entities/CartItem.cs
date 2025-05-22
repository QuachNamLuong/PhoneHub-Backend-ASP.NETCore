namespace PhoneHub.API.Data.Entities;

public class CartItem
{
    public int Id { get; set; }
    public int CartId {get; set;}
    public virtual Cart Cart { get; set; } = null!;
}
