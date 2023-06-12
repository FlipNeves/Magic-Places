using MagicPlaces_WEB.Models;
using static MagicPlaces_Utility.SD;
using static MagicPlaces_WEB.Models.APIRequest;

namespace MagicPlaces_WEB.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
        Task<T> ConsumeAPI<T>(ApiType method, string url, object data, APIToken token = null, APIParams headers = null);
    }
}
