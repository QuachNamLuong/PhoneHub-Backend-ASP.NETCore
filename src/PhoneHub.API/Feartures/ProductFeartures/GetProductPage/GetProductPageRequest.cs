using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneHub.API.Feartures.ProductFeartures.GetProductPage;

public record GetProductPageRequest(
    [Range(1, int.MaxValue)]
    int PageNumber,
    [Range(1, 20)]
    int NumberItem
);