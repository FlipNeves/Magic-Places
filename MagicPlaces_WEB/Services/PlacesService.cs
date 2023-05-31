using MagicPlaces_Utility;
using MagicPlaces_WEB.Models;
using MagicPlaces_WEB.Models.DTO;
using MagicPlaces_WEB.Services.IServices;
using MagicPlaces_WEB.Utils;
using Microsoft.Extensions.Options;

namespace MagicPlaces_WEB.Services
{
    public class PlacesService : BaseService, IPlacesService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ServicesUrlsConfig _servicesUrls;
        public PlacesService(IHttpClientFactory clientFactory, IOptions<ServicesUrlsConfig> servicesUrls) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _servicesUrls = servicesUrls.Value;
        }

        public Task<T> CreateAsync<T>(PlacesCreateDTO dtoPlaces)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dtoPlaces,
                Url = $"{_servicesUrls.PlacesAPI}/Places/"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = $"{_servicesUrls.PlacesAPI}/Places/{id}"
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{_servicesUrls.PlacesAPI}/Places/"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{_servicesUrls.PlacesAPI}/Places/{id}"
            });
        }

        public Task<T> UpdateAsync<T>(PlacesUpdateDTO dtoPlaces)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dtoPlaces,
                Url = $"{_servicesUrls.PlacesAPI}/Places/{dtoPlaces.Id}"
            });
        }
    }
}
