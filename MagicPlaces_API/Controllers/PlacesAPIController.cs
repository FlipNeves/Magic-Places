using MagicPlaces_API.Data;
using MagicPlaces_API.Models;
using MagicPlaces_API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicPlaces_API.Controllers
{
    [Route("/Places")]
    //[ApiController]
    public class PlacesAPIController : ControllerBase
    {
        private readonly ILogger<PlacesAPIController> logger;

        public PlacesAPIController(ILogger<PlacesAPIController> _logger)
        {
            logger = _logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PlacesDTO>> GetPlaces()
        {
            logger.LogInformation("Realizando busca dos lugares cadastrados!");
            return Ok(PlaceStore.PlacesList);
        }

        [HttpGet("{id:int}", Name = "GetPlace")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PlacesDTO> GetPlaces(int id)
        {
            if (id == 0)
            {
                logger.LogInformation("O parâmetro de Id do local não foi passado corretamente.");
                return BadRequest();
            }
            var place = PlaceStore.PlacesList.FirstOrDefault(place => place.Id == id);

            if (place == null)
            {
                logger.LogInformation($"O local com esse Id {id} não foi encontrado.");
                return NotFound();
            }
            logger.LogInformation($"Local encontrado pelo Id {id}");
            return Ok(place);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PlacesDTO> CreatePlace([FromBody] PlacesDTO placesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(placesDto == null)
            {
                return BadRequest(placesDto);
            }
            if(placesDto.Id != 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if(PlaceStore.PlacesList.Any(place => place.Name == placesDto.Name))
            {
                ModelState.AddModelError("Erro:", "Este local já foi registrado!");
                return BadRequest(ModelState);
            }
            placesDto.Id = PlaceStore.PlacesList.OrderByDescending(l => l.Id).FirstOrDefault().Id + 1;
            PlaceStore.PlacesList.Add(placesDto);

            logger.LogInformation("Novo local adicionado.");
            return CreatedAtRoute("GetPlace", new {id = placesDto.Id}, placesDto);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePlace(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var place = PlaceStore.PlacesList.FirstOrDefault(place => place.Id == id);

            if(place == null)
            {
                return NotFound();
            }
            PlaceStore.PlacesList.Remove(place);
            logger.LogInformation($"Local de id {id} foi removido.");
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePlace(int id, [FromBody] PlacesDTO placeDto)
        {
            if(placeDto == null || id != placeDto.Id)
            {
                return BadRequest();
            }

            var place = PlaceStore.PlacesList.FirstOrDefault(place => place.Id == id);
            place.Name = placeDto.Name;
            place.Value = placeDto.Value;
            place.Comment = placeDto.Comment;

            logger.LogInformation($"Local de id {id} foi atualizado.");
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePlace")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePlace(int id, JsonPatchDocument<PlacesDTO> objDto)
        {
            if(objDto == null || id == 0)
            {
                return BadRequest();
            }
            var place = PlaceStore.PlacesList.FirstOrDefault(place => place.Id == id);
            if(place == null)
            {
                return BadRequest();
            }
            objDto.ApplyTo(place, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            logger.LogInformation($"Local com id {id} teve um campo atualizado.");
            return NoContent();
        }

    }
}
