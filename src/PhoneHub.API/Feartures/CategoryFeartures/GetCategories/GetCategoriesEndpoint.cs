using Microsoft.AspNetCore.Mvc;
using PhoneHub.API.DTOs;
using PhoneHub.API.Response;

namespace PhoneHub.API.Feartures.CategoryFeartures.GetCategories;

[ApiController]
[Route("get-categories")]
public class GetCategoriesEndpoint(IGetCategoriesHandler getCategoriesHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesRequest request, CancellationToken cancellationToken)
    {
        var getCategoriesResult = await getCategoriesHandler.Handler(request, cancellationToken);
        if (getCategoriesResult.IsError)
        {
            return BadRequest(ApiResponse.Failure(getCategoriesResult.Errors));
        }
        return Ok(ApiResponse<List<CategoryDto>>.Success(getCategoriesResult.Value));
    }
}