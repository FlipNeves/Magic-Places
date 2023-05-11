using AutoMapper;
using MagicPlaces_API.Data;
using MagicPlaces_API.Models;
using MagicPlaces_API.Models.DTO;
using MagicPlaces_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicPlaces_API.Controllers
{
    [Route("/PlacesNumbers")]
    //[ApiController]
    public class PlacesNumbersAPIController : ControllerBase
    {
        private readonly APIResponse _response;
        private readonly IPlacesNumbersRepository _dbPlacesNumber;
        private readonly IPlacesRepository _dbPlaces;
        private readonly ILogger<PlacesNumbersAPIController> _logger;
        private readonly IMapper _mapper;

        public PlacesNumbersAPIController(ILogger<PlacesNumbersAPIController> logger, IPlacesNumbersRepository db, IMapper mapper, IPlacesRepository dbPlaces)
        {
            _dbPlacesNumber = db;
            _logger = logger;
            _mapper = mapper;
            this._response = new APIResponse();
            _dbPlaces = dbPlaces;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetPlacesNumber()
        {
            try
            {
                IEnumerable<PlacesNumber> placesNumberList = await _dbPlacesNumber.GetAllAsync();
                _response.Result = _mapper.Map<List<PlacesNumberDTO>>(placesNumberList);
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

        [HttpGet("{id:int}", Name = "GetPlaceNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetPlacesNumber(int id)
        {
            try
            {

                if (id == 0)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>
                    {
                        "O parâmetro de Id do local Number não foi passado corretamente."
                    };
                    return BadRequest(_response);
                }
                var placeNumber = await _dbPlacesNumber.GetAsync(number => number.PlaceNo == id);

                if (placeNumber == null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string>
                    {
                        $"O local Number com esse Id {id} não foi encontrado."
                    };
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<PlacesNumberDTO>(placeNumber);
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
        [Route("AdicionarPlaceNumber")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreatePlaceNumber([FromBody] PlaceNumberCreateDTO placesNumberDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { ModelState.ToList().ToString() };
                    return BadRequest(ModelState);
                }
                if (placesNumberDto == null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                if (await _dbPlaces.GetAsync(x => x.Id == placesNumberDto.PlaceId) == null)
                {
                    ModelState.AddModelError("CustomError", "PlaceID inválido");
                    return BadRequest(_response);
                }

                if (await _dbPlacesNumber.GetAsync(placeNo => placeNo.PlaceNo == placesNumberDto.PlaceNo) != null)
                {
                    var mensagem = "Este local Number já foi registrado!";
                    ModelState.AddModelError("Erro:", mensagem);
                    return BadRequest(ModelState);
                }
                var placesNumber = _mapper.Map<PlacesNumber>(placesNumberDto);

                await _dbPlacesNumber.CreateAsync(placesNumber);

                _logger.LogInformation("Novo local Number adicionado.");

                _response.Result = _mapper.Map<PlacesNumberDTO>(placesNumber);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                return CreatedAtRoute("GetPlaceNumber", new { id = placesNumber.PlaceNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeletePlaceNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var placeNumber = await _dbPlacesNumber.GetAsync(placeNo => placeNo.PlaceNo == id);

                if (placeNumber == null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _dbPlacesNumber.RemoveAsync(placeNumber);
                _logger.LogInformation($"Local Number de id {id} foi removido.");
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePlaceNumber(int id, [FromBody] PlaceNumberUpdateDTO placeNumberDto)
        {
            try
            {
                if (placeNumberDto == null || id != placeNumberDto.PlaceNo)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if (await _dbPlaces.GetAsync(x => x.Id == placeNumberDto.PlaceId) == null)
                {
                    ModelState.AddModelError("CustomError", "PlaceID inválido");
                    return BadRequest(_response);
                }

                var placesNumber = _mapper.Map<PlacesNumber>(placeNumberDto);


                await _dbPlacesNumber.UpdateAsync(placesNumber);

                _logger.LogInformation($"Local Number de id {id} foi atualizado.");
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
