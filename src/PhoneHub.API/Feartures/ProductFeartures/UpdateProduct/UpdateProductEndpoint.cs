using Microsoft.AspNetCore.Mvc;
using PhoneHub.API.Response;

namespace PhoneHub.API.Feartures.ProductFeartures.UpdateProduct;

[ApiController]
[Route("update-product")]
public class UpdateProductEndpoint(IUpdateProductHandler updateProductHandler) : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductResquest request, CancellationToken cancellationToken)
    {
        var updateProductResult = await updateProductHandler.UpdateProduct(request, cancellationToken);
        if (updateProductResult.IsError)
        {
            return BadRequest(ApiResponse<UpdateProductDto>.Failure(updateProductResult.Errors));
        }

        return Ok(ApiResponse<UpdateProductDto>.Success(updateProductResult.Value));
    }
}