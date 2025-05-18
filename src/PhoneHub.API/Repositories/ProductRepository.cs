
using Microsoft.EntityFrameworkCore;

namespace PhoneHub.API.Repositories;

public class ProductRepository(
    AppDbContext dbContext
) : IProductServices
{
    public async Task CreateProduct(Product newProduct, CancellationToken cancellationToken)
    {
        await dbContext.Products.AddAsync(newProduct, cancellationToken);
    }

    public async Task DeleteProduct(Product productToDelete, CancellationToken cancellationToken)
    {
        dbContext.Products.Remove(productToDelete);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Product>> GetProducts(CancellationToken cancellationToken)
    {
        return await dbContext.Products.ToListAsync(cancellationToken);
    }

    public async Task UpdateProduct(Product updatedProduct, CancellationToken cancellationToken)
    {
        dbContext.Products.Update(updatedProduct);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}