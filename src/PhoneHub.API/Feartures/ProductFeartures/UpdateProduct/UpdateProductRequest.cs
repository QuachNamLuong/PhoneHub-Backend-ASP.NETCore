using System.Text.Json.Serialization;

namespace PhoneHub.API.Feartures.ProductFeartures.UpdateProduct;

public record UpdateProductResquest(
    [property: JsonPropertyName("id")]
    int Id,
    [property: JsonPropertyName("name")]
    string Name
);