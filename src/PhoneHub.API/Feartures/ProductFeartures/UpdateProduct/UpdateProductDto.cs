using System.Text.Json.Serialization;

namespace PhoneHub.API.Feartures.ProductFeartures.UpdateProduct;

public record UpdateProductDto(
    [property: JsonPropertyName("id")]
    int Id,
    [property: JsonPropertyName("name")]
    string Name
);