using GodlessAPI.Data;
using GodlessAPI.Models;
using GodlessAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GodlessAPI.Controllers;
[Route("api/GodlessAPI")]
[ApiController]
public class GodlessAPIController : ControllerBase
{
    private readonly ILogger<GodlessAPIController> _logger;

    public GodlessAPIController(ILogger<GodlessAPIController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<GodlessDTO> GetGodless()
    {

        _logger.LogInformation("Endpoint called successful");

        return GodlessStore.GodlessList;
    }

    [HttpGet("{id:int}", Name = "GetGod")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // You can do it like this as well

    //[ProducesResponseType(200, Type= typeof(GodlessDTO))]
    public ActionResult<GodlessDTO> GetGod(int id)
    {
        if(id == 0)
        {
            _logger.LogError($"Invalid id provided: {id} !");
            return BadRequest();
        }

        var god = GodlessStore.GodlessList.FirstOrDefault(god => god.Id == id);

        if(god == null)
        {
            return NotFound();
        }

        return Ok(god);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<GodlessDTO> CreateGod([FromBody] GodlessDTO godlessDTO)
    {
        if (godlessDTO == null)
        { 
            return BadRequest(godlessDTO);
        }

        if (godlessDTO.Id > 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        godlessDTO.Id = GodlessStore.GodlessList.OrderByDescending(god => god.Id).FirstOrDefault().Id + 1;

        GodlessStore.GodlessList.Add(godlessDTO);

        return CreatedAtRoute("GetGod", new {id = godlessDTO.Id} , godlessDTO);
    }

    [HttpDelete("{id:int}", Name = "RemoveGod")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult RemoveGod(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }
        var god = GodlessStore.GodlessList.FirstOrDefault(g => g.Id == id); 

        if (god == null)
        {
            return NotFound();
        }

        GodlessStore.GodlessList.Remove(god);

        return NoContent();
    }
    [HttpPut("{id:int}", Name = "UpdateGod")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateGod(int id, [FromBody]GodlessDTO god)
    {
        if (id != god.Id || god == null)
        {
            return BadRequest();
        }

        var update = GodlessStore.GodlessList.FirstOrDefault(x => x.Id == id);

        update.Name = god.Name;
        update.Pantheon = god.Pantheon;
        update.Universe = god.Universe;
        

        return NoContent();
    }

    [HttpPatch("{id:int}", Name = "PatchGod")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PatchGod (int id, JsonPatchDocument<GodlessDTO> patch)
    {
        if (patch == null || id == 0)
        {
            return BadRequest();
        }

        var god = GodlessStore.GodlessList.First(obj => obj.Id == id);

        if(god == null)
        {
            return BadRequest();
        }

        patch.ApplyTo(god, ModelState);

        if(!ModelState.IsValid)
        {
            return BadRequest();
        }
        return NoContent();
    }
}
