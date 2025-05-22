using PhoneHub.API.DTOs;

namespace PhoneHub.API.Mappers;

public static class CreateCategoryMappers
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new(
            category.Id,
            category.Name
        );
    }
}