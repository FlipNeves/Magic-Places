using AutoMapper;
using MagicPlaces_WEB.Extensions;
using MagicPlaces_WEB.Models;
using MagicPlaces_WEB.Models.DTO;
using MagicPlaces_WEB.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MagicPlaces_WEB.Controllers
{
    public class PlacesController : Controller
    {
        private readonly IPlacesService _placesService;
        private readonly IMapper _mapper;

        public PlacesController(IPlacesService placesService, IMapper mapper)
        {
            _placesService = placesService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listPlaces = new List<PlacesDTO>();
            var response = await _placesService.GetAllAsync<APIResponse>();
            if(response.IsValid())
            {
                listPlaces = JsonConvert.DeserializeObject<List<PlacesDTO>>(Convert.ToString(response.Result));
            }
            return View(listPlaces);
        }

        public async Task<IActionResult> DeletePlace(int id)
        {
            var response = await _placesService.DeleteAsync<APIResponse>(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditPlace(int id)
        {
            var response = await _placesService.GetAsync<APIResponse>(id);
            if(response.IsValid())
            {
                var place = JsonConvert.DeserializeObject<PlacesDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<PlacesUpdateDTO>(place));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPlace(PlacesUpdateDTO place)
        {
            if (ModelState.IsValid)
            {
                var response = await _placesService.UpdateAsync<APIResponse>(place);
                if (response.IsValid())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(place);
        }

        public async Task<IActionResult> CreatePlace()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePlace(PlacesCreateDTO place)
        {
            if (ModelState.IsValid)
            {
                var response = await _placesService.CreateAsync<APIResponse>(place);
                if(response.IsValid())
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(place);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}