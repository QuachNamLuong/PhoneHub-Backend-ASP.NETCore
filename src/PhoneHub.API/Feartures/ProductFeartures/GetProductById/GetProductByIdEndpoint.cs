using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PhoneHub.API.Response;

namespace PhoneHub.API.Feartures.ProductFeartures.GetProductById;

[ApiController]
[Route("get-product")]
public class GetProductByIdEndpoint(IGetProductByIdHandler getProductByIdHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProductById([FromQuery] GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var getProductByIdResult = await getProductByIdHandler.GetProductByIdAsync(request, cancellationToken);

        if (getProductByIdResult.IsError && getProductByIdResult.FirstError == GetProductByIdErrors.ProductNotFound)
            return NotFound(ApiResponse<GetProductByIdDto>.Failure(getProductByIdResult.Errors));

        return Ok(ApiResponse<GetProductByIdDto>.Success(getProductByIdResult.Value));
    }
}