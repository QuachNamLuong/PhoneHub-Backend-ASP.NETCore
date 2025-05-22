using Microsoft.AspNetCore.Mvc;

namespace PhoneHub.API.Feartures.ProductFeartures.CreateProduct;

[ApiController]
[Route("create-product")]
public class CreateProductEndpoint(ICreateProductHandler createProductHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var createProductResult = await createProductHandler.CreateProductAsync(request, cancellationToken);
        if (createProductResult.IsError) return BadRequest();

        var newProduct = createProductResult.Value;

        return CreatedAtAction(
            nameof(CreateProduct),
            newProduct
        );
    }
}