using Microsoft.AspNetCore.Mvc;
using PhoneHub.API.Response;

namespace PhoneHub.API.Feartures.CategoryFeartures.DeleteCategory;

[ApiController]
[Route("delete-category")]
public class DeleteCategoryEndpoint(IDeleteCategoryHandler deleteCategoryHandler) : ControllerBase
{
    [HttpDelete]
    public async Task<IActionResult> UpdateCategory([FromQuery] DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var updateCategoryResult = await deleteCategoryHandler.UpdateCategory(request, cancellationToken);
        if (updateCategoryResult.IsError)
        {
            return BadRequest(ApiResponse.Failure(updateCategoryResult.Errors));
        }

        return NoContent();
    }
}