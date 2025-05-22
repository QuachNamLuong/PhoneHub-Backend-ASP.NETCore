namespace PhoneHub.API.Feartures.ProductFeartures.GetProductPage;

public static class Mappers
{
    public static ProductPageItemDto ToProductPageItem(this Product product)
    {
        return new ProductPageItemDto(
            product.Id,
            product.Name
        );
    }
}