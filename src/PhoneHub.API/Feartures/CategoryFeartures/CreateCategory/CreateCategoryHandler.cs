using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace PhoneHub.API.Feartures.CategoryFeartures.CreateCategory;

public interface ICreateCategoryHandler
{
    Task<ErrorOr<CategoryDto>> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken);
}


public class CreateCategoryHandler(AppDbContext dbContext) : ICreateCategoryHandler
{
    public async Task<ErrorOr<CategoryDto>> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var isCategoryNameExits = await dbContext.Categories.AnyAsync(c => c.Name == request.Name, cancellationToken);
        if (isCategoryNameExits)
        {
            return CreateCategoryErrors.CategoryNameExitsError;
        }

        var newCategory = (await dbContext.Categories.AddAsync(request.ToCategory(), cancellationToken)).Entity;
        await dbContext.SaveChangesAsync(cancellationToken);
        return newCategory.ToDto();
    }
}