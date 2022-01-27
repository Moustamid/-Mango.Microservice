using Mango.Web.Models;
using Mango.Web.Models.Dto;

namespace Mango.Web.Services.IServices;

public interface IBaseService : IDisposable
{
    public ResponseDto responseModel { get; set; }
    
    public Task<T> SendAsync<T>(ApiRequest apiRequest);
    
}