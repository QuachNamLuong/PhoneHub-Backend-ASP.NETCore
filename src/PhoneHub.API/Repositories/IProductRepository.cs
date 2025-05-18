namespace PhoneHub.API.Repositories;

public interface IProductServices
{
    Task<List<Product>> GetProducts(CancellationToken cancellationToken);
    Task CreateProduct(Product newProduct, CancellationToken cancellationToken);
    Task UpdateProduct(Product updatedProduct, CancellationToken cancellationToken);
    Task DeleteProduct(Product productToDelete, CancellationToken cancellationToken);
}