using Microsoft.AspNetCore.Mvc;
using PhoneHub.API.Response;

namespace PhoneHub.API.Feartures.ProductFeartures.DeleteProduct;

[ApiController]
[Route("delete-product")]
public class DeleteProductEndpoint(IDeleteProductHandler deleteProductHandler) : ControllerBase
{
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct([FromQuery]DeleteProdcutRequest request, CancellationToken cancellationToken)
    {
        var deleteProductResult = await deleteProductHandler.DeleteProductAsync(request, cancellationToken);
        if (deleteProductResult.IsError)
        {
            return BadRequest(ApiResponse.Failure(deleteProductResult.Errors));
        }
        return Ok(ApiResponse.Success());
    }
}