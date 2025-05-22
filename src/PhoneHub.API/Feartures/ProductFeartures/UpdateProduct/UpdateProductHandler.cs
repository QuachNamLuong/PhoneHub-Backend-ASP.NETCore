using ErrorOr;

namespace PhoneHub.API.Feartures.ProductFeartures.UpdateProduct;

public interface IUpdateProductHandler
{
    Task<ErrorOr<UpdateProductDto>> UpdateProduct(
        UpdateProductResquest resquest,
        CancellationToken cancellationToken
    );
}

public class UpdateProductHandler(AppDbContext dbContext) : IUpdateProductHandler
{
    public async Task<ErrorOr<UpdateProductDto>> UpdateProduct(
        UpdateProductResquest resquest,
        CancellationToken cancellationToken
    )
    {
        var productToUpdate = await dbContext.Products.FindAsync([resquest.Id], cancellationToken);
        if (productToUpdate is null)
        {
            return Error.NotFound("UpdateProductHandler.UpdateProduct", "Product is not found");
        }
        productToUpdate.UpdateProduct(resquest);
        await dbContext.SaveChangesAsync(cancellationToken);

        return productToUpdate.ToUpdateProductDto();
    }
}