using System.Text.Json.Serialization;

namespace PhoneHub.API.Feartures.ProductFeartures.CreateProduct;

public record CreateProductRequest(
    [property: JsonPropertyName("name")]
    string Name,
    IFormFile Image
);
