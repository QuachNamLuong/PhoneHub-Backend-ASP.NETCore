namespace PhoneHub.API.Feartures.CategoryFeartures.CreateCategory;

public static class CreateCategoryMappers
{
    public static Category ToCategory(this CreateCategoryRequest request)
    {
        return new()
        {
            Name = request.Name
        };
    }

    public static CategoryDto ToDto(this Category category)
    {
        return new(
            category.Id,
            category.Name
        );
    }
}