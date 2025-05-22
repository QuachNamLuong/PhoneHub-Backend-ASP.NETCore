using ErrorOr;

namespace PhoneHub.API.Feartures.CategoryFeartures.CreateCategory;

public static class CreateCategoryErrors
{
    private const int CategoryNameExits = 1;

    public static Error CategoryNameExitsError
        => Error.Custom(
            type: CategoryNameExits,
            code: "CreateCategory.CategoryNameExits",
            description: "Category name already exits"
        );
}