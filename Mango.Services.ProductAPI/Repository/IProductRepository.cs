using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetProducts();

    Task<ProductDto> GetProductById(int productId);

    Task<ProductDto> CreatOrUpdateProduct(ProductDto productDto);

    Task<bool> DeleteProduct(int productId);
}