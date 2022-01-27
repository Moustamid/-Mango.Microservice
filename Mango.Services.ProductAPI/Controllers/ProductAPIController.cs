using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers;

[Route("api/products")]
public class ProductApiController : ControllerBase
{
    private readonly ResponseDto _response;
    private readonly IProductRepository _productRepo;

    public ProductApiController(IProductRepository productRepo)
    {
        _response = new ResponseDto();
        _productRepo = productRepo;
    }
    
    
    //.GET
    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            var productDtos = await _productRepo.GetProducts();
            _response.Result = productDtos;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    //.GET By Id
    [HttpGet]
    [Route("{id:int}")]
    public async Task<object> Get(int id)
    {
        try
        {
            var productDtos = await _productRepo.GetProductById(id);
            _response.Result = productDtos;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    //.Post
    [HttpPost]
    public async Task<object> Post([FromBody] ProductDto productDto)
    {
        try
        {
            var dtoModel = await _productRepo.CreatOrUpdateProduct(productDto);
            _response.Result = dtoModel;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
      
    //.Put
    [HttpPut]
    public async Task<object> Put([FromBody] ProductDto productDto)
    {
        try
        {
            var dtoModel = await _productRepo.CreatOrUpdateProduct(productDto);
            _response.Result = dtoModel;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
      
    //.Delete
    [HttpDelete]
    public async Task<object> Delete(int id)
    {
        try
        {
            var isSuccess = await _productRepo.DeleteProduct(id);
            // ReSharper disable once HeapView.BoxingAllocation
            _response.Result = isSuccess;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
}