using ErrorOr;
using Minio;
using Minio.DataModel.Args;
using PhoneHub.API.Services;

namespace PhoneHub.API.Feartures.ProductFeartures.CreateProduct;


public interface ICreateProductHandler
{
    Task<ErrorOr<CreateProductDto>> CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken);
}

public class CreateProductHandler(
    AppDbContext dbContext,
    IMinioService minioService
) : ICreateProductHandler
{
    private const string _bucketName = "product-images";
    public async Task<ErrorOr<CreateProductDto>> CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var newProduct = request.ToProduct();
        newProduct.ImageUrl = await minioService.UploadImage(_bucketName, request.Image, cancellationToken);

        await dbContext.Products.AddAsync(newProduct, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return newProduct.ToCreateProductDto();
    }
}