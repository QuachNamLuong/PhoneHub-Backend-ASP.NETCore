namespace PhoneHub.API.Feartures.ProductFeartures.CreateProduct;

public static class CreateProductMappers
{
    public static Product ToProduct(this CreateProductRequest createProductRequest)
    {
        return new Product
        {
            Name = createProductRequest.Name
        };
    }

    public static CreateProductDto ToCreateProductDto(this Product product)
    {
        return new CreateProductDto(product.Id, product.Name, product.ImageUrl);
    }
}