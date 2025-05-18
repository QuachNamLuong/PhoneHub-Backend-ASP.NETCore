using Microsoft.AspNetCore.Mvc;

namespace PhoneHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(
    IProductServices productServices
) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        await productServices.CreateProduct();
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct()
    {
        await productServices.CreateProduct();
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct()
    {
        await productServices.CreateProduct();
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct()
    {
        await productServices.CreateProduct();
        return NoContent();
    }
}
