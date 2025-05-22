using ErrorOr;

namespace PhoneHub.API.Feartures.CategoryFeartures.DeleteCategory;

public interface IDeleteCategoryHandler
{
    Task<ErrorOr<bool>> UpdateCategory(DeleteCategoryRequest request, CancellationToken cancellationToken);
}

public class DeleteCategoryHandler(AppDbContext dbContext) : IDeleteCategoryHandler
{
    public async Task<ErrorOr<bool>> UpdateCategory(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var categoryToUpdate = await dbContext.Categories.FindAsync([request.Id], cancellationToken);
        if (categoryToUpdate is null)
        {
            return Error.Custom(1, "CategoryNotFound", "CategoryNotFound");
        }
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}