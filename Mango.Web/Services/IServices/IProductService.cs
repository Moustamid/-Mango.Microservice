using Mango.Web.Models.Dto;

namespace Mango.Web.Services.IServices;

public interface IProductService
{
    Task<T> GetAllProductsAsync<T>();

    Task<T> GetProductByIdAsync<T>(int id);

    Task<T> UpdateProductAsync<T>(ProductDto productDto);
    
    Task<T> CreatProductAsync<T>(ProductDto productDto);

    Task<bool> DeleteProduct(int id);
    
}