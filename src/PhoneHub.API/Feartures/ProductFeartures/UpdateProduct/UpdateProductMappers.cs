namespace PhoneHub.API.Feartures.ProductFeartures.UpdateProduct;

public static class UpdateProductMappers
{
    public static Product UpdateProduct(this Product product, UpdateProductResquest updateProductResquest)
    {
        product.Name = updateProductResquest.Name;
        return product;
    }

    public static UpdateProductDto ToUpdateProductDto(this Product product)
    {
        return new UpdateProductDto(product.Id, product.Name);
    }
}