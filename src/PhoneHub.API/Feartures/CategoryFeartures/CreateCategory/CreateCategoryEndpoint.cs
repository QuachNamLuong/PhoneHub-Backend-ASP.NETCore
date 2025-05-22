using Microsoft.AspNetCore.Mvc;
using PhoneHub.API.Response;

namespace PhoneHub.API.Feartures.CategoryFeartures.CreateCategory;

[ApiController]
[Route("create-category")]
public class CreateCategoryEndpoint(ICreateCategoryHandler handler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var createCategoryResult = await handler.CreateCategory(request, cancellationToken);
        if (createCategoryResult.IsError)
        {
            return BadRequest(ApiResponse.Failure(createCategoryResult.Errors));
        }
        var newCategory = createCategoryResult.Value;
        return CreatedAtAction(nameof(CreateCategory), newCategory.Id, newCategory);
    }
}