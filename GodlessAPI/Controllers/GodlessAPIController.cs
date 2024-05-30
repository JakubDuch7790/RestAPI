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
    private readonly ApplicationDbContext _db;

    public GodlessAPIController(ILogger<GodlessAPIController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<GodlessDTO>>  GetGodless()
    {
        return Ok(_db.Gods);
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

        var god = _db.Gods.FirstOrDefault(god => god.Id == id);

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

        Godless newGod = new()
        {
            Name = godlessDTO.Name,
            Creation = godlessDTO.Creation

        };

        _db.Gods.Add(newGod);
        _db.SaveChanges();

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
        var god = _db.Gods.FirstOrDefault(g => g.Id == id); 

        if (god == null)
        {
            return NotFound();
        }

        _db.Gods.Remove(god);
        _db.SaveChanges();

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

        var update = _db.Gods.FirstOrDefault(x => x.Id == id);

        Godless newGod = new()
        {
            Name = god.Name,
            Creation = god.Creation

        };

        _db.Gods.Update(newGod);
        _db.SaveChanges();

        //update.Name = god.Name;
        //update.Pantheon = god.Pantheon;
        //update.Universe = god.Universe;
        

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

        var god = _db.Gods.First(obj => obj.Id == id);

        GodlessDTO gotPatch = new()
        {
            Name = god.Name,
            Creation = god.Creation
        };

        if(god == null)
        {
            return BadRequest();
        }

        patch.ApplyTo(gotPatch, ModelState);

        Godless patchedGod = new()
        {
            Name = gotPatch.Name,
            Creation = gotPatch.Creation
        };

        _db.Gods.Update(patchedGod);
        _db.SaveChanges();

        if(!ModelState.IsValid)
        {
            return BadRequest();
        }
        return NoContent();
    }
}
