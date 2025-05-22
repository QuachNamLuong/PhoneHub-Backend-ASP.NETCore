using System.Text.Json.Serialization;

namespace PhoneHub.API.Feartures.ProductFeartures.CreateProduct;

public record CreateProductDto(
    [property: JsonPropertyName("id")]
    int Id,
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("image-url")]
    string ImageUrl
);