using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace PhoneHub.API.Feartures.ProductFeartures.GetProductPage;

public interface IGetProductPageHandler
{
    Task<ErrorOr<List<ProductPageItemDto>>> GetProductPageAsync(GetProductPageRequest request, CancellationToken cancellationToken);
}

public class GetProductPageHandler(AppDbContext dbContext) : IGetProductPageHandler
{
    public async Task<ErrorOr<List<ProductPageItemDto>>> GetProductPageAsync(GetProductPageRequest request, CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .Skip((request.PageNumber - 1)* request.NumberItem)
            .Take(request.NumberItem)
            .Select(p => p.ToProductPageItem())
            .ToListAsync(cancellationToken);
    }
}