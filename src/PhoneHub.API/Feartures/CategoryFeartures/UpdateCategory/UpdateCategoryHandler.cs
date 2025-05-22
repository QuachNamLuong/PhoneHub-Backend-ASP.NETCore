using ErrorOr;

namespace PhoneHub.API.Feartures.CategoryFeartures.UpdateCategory;

public interface IUpdateCategoryHandler
{
    Task<ErrorOr<CategoryDto>> UpdateCategory(UpdateCategoryRequest request, CancellationToken cancellationToken);
}

public class UpdateCategoryHandler(AppDbContext dbContext) : IUpdateCategoryHandler
{
    public async Task<ErrorOr<CategoryDto>> UpdateCategory(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var categoryToUpdate = await dbContext.Categories.FindAsync([request.Id], cancellationToken);
        if (categoryToUpdate is null)
        {
            return Error.Custom(1, "CategoryNotFound", "CategoryNotFound");
        }
        categoryToUpdate.Update(request);
        await dbContext.SaveChangesAsync(cancellationToken);
        return categoryToUpdate.ToDto();
    }
}