
using ErrorOr;

namespace PhoneHub.API.Feartures.ProductFeartures.GetProductById;


public static class GetProductByIdErrors
{
    public static Error ProductNotFound => Error.Custom(
        type: GetProductByIdErrorType.ProductNotFound,
        code: "Product.NotFound",
        description: "Product not found"
    );
}