using ErrorOr;
using Microsoft.EntityFrameworkCore;
using PhoneHub.API.DTOs;
using PhoneHub.API.Mappers;

namespace PhoneHub.API.Feartures.CategoryFeartures.GetCategories;

public interface IGetCategoriesHandler
{
    Task<ErrorOr<List<CategoryDto>>> Handler(GetCategoriesRequest request, CancellationToken cancellationToken);
}

public class GetCategoriesHandler(AppDbContext dbContext) : IGetCategoriesHandler
{
    public async Task<ErrorOr<List<CategoryDto>>> Handler(GetCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await dbContext.Categories
            .AsNoTracking()
            .Select(c => c.ToCategoryDto())
            .ToListAsync(cancellationToken);
            
        return categories;
    }
}