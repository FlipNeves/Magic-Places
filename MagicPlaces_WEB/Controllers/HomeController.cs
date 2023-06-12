using AutoMapper;
using MagicPlaces_WEB.Extensions;
using MagicPlaces_WEB.Models;
using MagicPlaces_WEB.Models.DTO;
using MagicPlaces_WEB.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicPlaces_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlacesService _placesService;
        private readonly IMapper _mapper;

        public HomeController(IPlacesService placesService, IMapper mapper)
        {
            _placesService = placesService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listPlaces = new List<PlacesDTO>();
            var response = await _placesService.GetMostPositivePlaces<APIResponse>();
            if (response.IsValid())
            {
                listPlaces = JsonConvert.DeserializeObject<List<PlacesDTO>>(Convert.ToString(response.Result));
            }
            return View(listPlaces);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
