using Microsoft.AspNetCore.Mvc;
using PhoneHub.API.Response;

namespace PhoneHub.API.Feartures.ProductFeartures.GetProductPage;

[ApiController]
[Route("get-product-page")]
public class GetProductPageEndpoint(IGetProductPageHandler getProductPageHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProductPage([FromQuery] GetProductPageRequest request, CancellationToken cancellationToken)
    {
        var getProductPageResult = await getProductPageHandler.GetProductPageAsync(request, cancellationToken);
        var products = getProductPageResult.Value;
        return Ok(ApiResponse<List<ProductPageItemDto>>.Success(products));
    }   
}