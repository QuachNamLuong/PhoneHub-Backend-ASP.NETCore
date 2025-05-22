using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace PhoneHub.API.Feartures.ProductFeartures.GetProductById;

public interface IGetProductByIdHandler
{
    Task<ErrorOr<GetProductByIdDto>> GetProductByIdAsync(GetProductByIdRequest request, CancellationToken cancellationToken);
}

public class GetProductByIdHandler(AppDbContext dbContext) : IGetProductByIdHandler
{
    public async Task<ErrorOr<GetProductByIdDto>> GetProductByIdAsync(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FindAsync([request.Id], cancellationToken);

        if (product is not null) return product.ToDto();
        
        return GetProductByIdErrors.ProductNotFound;
    }
}
