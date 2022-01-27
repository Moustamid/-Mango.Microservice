using AutoMapper;
using Mango.Services.ProductAPI.DbContext;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private IMapper _mapper;

    public ProductRepository(ApplicationDbContext db , IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    //.Get All
    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        IEnumerable<Product> productList = await _db.Products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(productList);
    }
    
    //.Get By Id
    public async Task<ProductDto> GetProductById(int productId)
    {
        var product = await _db.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
        return _mapper.Map<ProductDto>(product);
    }
    
    //. Create Or Update
    public async Task<ProductDto> CreatOrUpdateProduct(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);

        if (product.ProductId > 0)
        {
            //- Update :
            _db.Products.Update(product);
        }
        else
        {
            //- Create :
            _db.Products.Add(product);
        }
        
        await _db.SaveChangesAsync();
        
        return _mapper.Map<ProductDto>(product);
    }
    
    //.Delete
    public async Task<bool> DeleteProduct(int productId)
    {
        try
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null) return false;
            
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    } 
}