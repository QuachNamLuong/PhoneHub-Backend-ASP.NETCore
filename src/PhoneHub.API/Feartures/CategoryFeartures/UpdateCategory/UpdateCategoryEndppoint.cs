using Microsoft.AspNetCore.Mvc;
using PhoneHub.API.Response;

namespace PhoneHub.API.Feartures.CategoryFeartures.UpdateCategory;

[ApiController]
[Route("update-category")]
public class UpdateCategoryEndpoint(IUpdateCategoryHandler updateCategoryHandler) : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var updateCategoryResult = await updateCategoryHandler.UpdateCategory(request, cancellationToken);
        if (updateCategoryResult.IsError)
        {
            return BadRequest(ApiResponse.Failure(updateCategoryResult.Errors));
        }

        return Ok(ApiResponse<CategoryDto>.Success(updateCategoryResult.Value));
    }
}