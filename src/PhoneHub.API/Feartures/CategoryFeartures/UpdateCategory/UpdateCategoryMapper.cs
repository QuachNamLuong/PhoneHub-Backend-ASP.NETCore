namespace PhoneHub.API.Feartures.CategoryFeartures.UpdateCategory;

public static class UpdateCategoryMapper
{
    public static void Update(
        this Category category,
        UpdateCategoryRequest updateCategoryRequest
    )
    {
        category.Name = updateCategoryRequest.Name;
    }

    public static CategoryDto ToDto(this Category category)
    {
        return new(category.Id, category.Name);
    }
}