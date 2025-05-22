using ErrorOr;

namespace PhoneHub.API.Feartures.ProductFeartures.DeleteProduct;

public interface IDeleteProductHandler
{
    public Task<ErrorOr<bool>> DeleteProductAsync(DeleteProdcutRequest request, CancellationToken cancellationToken);
}

public class DeleteProductHandler(AppDbContext appDbContext) : IDeleteProductHandler
{
    public async Task<ErrorOr<bool>> DeleteProductAsync(DeleteProdcutRequest request, CancellationToken cancellationToken)
    {
        var productToDelete = await appDbContext.Products.FindAsync([request.Id], cancellationToken);
        if (productToDelete is null)
        {
            return Error.NotFound("DeleteProductHandler.DeleteProductAsync", "Product to delete is not found");
        }

        appDbContext.Products.Remove(productToDelete);
        await appDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}