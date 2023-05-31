using MagicPlaces_WEB.Models;

namespace MagicPlaces_WEB.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
