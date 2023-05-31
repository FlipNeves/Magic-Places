using MagicPlaces_Utility;
using MagicPlaces_WEB.Models;
using MagicPlaces_WEB.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace MagicPlaces_WEB.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest request)
        {
            try
            {
                var client = httpClient.CreateClient("MagicAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.Url);
                if(request.Data != null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
                
                message.Method = request.ApiType switch
                {
                    SD.ApiType.POST     => HttpMethod.Post,
                    SD.ApiType.PUT      => HttpMethod.Put,
                    SD.ApiType.DELETE   => HttpMethod.Delete,
                    _                   => HttpMethod.Get
                };

                var response = await client.SendAsync(message);
                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<T>(content);
                return apiResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponse = JsonConvert.DeserializeObject<T>(res);
                return apiResponse;
            }
        }
    }
}
