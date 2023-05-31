using AutoMapper;
using MagicPlaces_API.Models;
using MagicPlaces_API.Models.DTO;
using MagicPlaces_API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MagicPlaces_API.Controllers
{
    [Route("/Places")]
    //[ApiController]
    public class PlacesAPIController : ControllerBase
    {
        private readonly APIResponse _response;
        private readonly IPlacesRepository _dbPlaces;
        private readonly ILogger<PlacesAPIController> _logger;
        private readonly IMapper _mapper;

        public PlacesAPIController(ILogger<PlacesAPIController> logger, IPlacesRepository db, IMapper mapper)
        {
            _dbPlaces = db;
            _logger = logger;
            _mapper = mapper;
            this._response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetPlaces()
        {
            try
            {
                IEnumerable<Places> placesList = await _dbPlaces.GetAllAsync();
                _response.Result = _mapper.Map<List<PlacesDTO>>(placesList);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };

            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetPlace")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetPlaces(int id)
        {
            try
            {

                if (id == 0)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>
                    {
                        "O parâmetro de Id do local não foi passado corretamente."
                    };
                    return BadRequest(_response);
                }
                var place = await _dbPlaces.GetAsync(place => place.Id == id);

                if (place == null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string>
                    {
                        $"O local com esse Id {id} não foi encontrado."
                    };
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<PlacesDTO>(place);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };

            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreatePlace([FromBody] PlacesCreateDTO placesDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { ModelState.ToList().ToString() };
                    return BadRequest(ModelState);
                }
                if (placesDto == null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                if (await _dbPlaces.GetAsync(place => place.Name.ToLower() == placesDto.Name.ToLower()) != null)
                {
                    var mensagem = "Este local já foi registrado!";
                    ModelState.AddModelError("Erro:", mensagem);
                    return BadRequest(ModelState);
                }
                var places = _mapper.Map<Places>(placesDto);

                await _dbPlaces.CreateAsync(places);

                _logger.LogInformation("Novo local adicionado.");

                _response.Result = _mapper.Map<PlacesDTO>(places);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                return CreatedAtRoute("GetPlace", new { id = places.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeletePlace(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var place = await _dbPlaces.GetAsync(place => place.Id == id);

                if (place == null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _dbPlaces.RemoveAsync(place);
                _logger.LogInformation($"Local de id {id} foi removido.");
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePlace(int id, [FromBody] PlacesUpdateDTO placesDto)
        {
            try
            {
                if (placesDto == null || id != placesDto.Id)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var places = _mapper.Map<Places>(placesDto);


                await _dbPlaces.UpdateAsync(places);

                _logger.LogInformation($"Local de id {id} foi atualizado.");
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }

    }
}
