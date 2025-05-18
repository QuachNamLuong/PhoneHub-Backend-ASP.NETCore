using PhoneHub.API.Models;

namespace PhoneHub.API.Services;

public interface IProductServices
{
    Task<List<Product>> GetProducts();
    Task<Product> GetProduct();
    Task CreateProduct();
    Task UpdateProduct();
    Task DeleteProduct();
}