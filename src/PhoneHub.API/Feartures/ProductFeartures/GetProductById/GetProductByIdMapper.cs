
namespace PhoneHub.API.Feartures.ProductFeartures.GetProductById;

public static class GetProductByIdMapper
{
    public static GetProductByIdDto ToDto(this Product product)
    {
        return new GetProductByIdDto(product.Id, product.Name, product.ImageUrl);
    }
}