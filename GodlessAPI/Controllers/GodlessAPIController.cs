using GodlessAPI.Data;
using GodlessAPI.Models;
using GodlessAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<IEnumerable<GodlessDTO>>>  GetGodless()
    {
        return  Ok(await _db.Gods.ToListAsync());
    }

    [HttpGet("{id:int}", Name = "GetGod")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // You can do it like this as well

    //[ProducesResponseType(200, Type= typeof(GodlessDTO))]
    public async Task<ActionResult<GodlessDTO>> GetGod(int id)
    {
        if(id == 0)
        {
            _logger.LogError($"Invalid id provided: {id} !");
            return BadRequest();
        }

        var god = await _db.Gods.FirstOrDefaultAsync(god => god.Id == id);

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
    public async Task<ActionResult<GodlessDTO>> CreateGod([FromBody] GodlessCreatedDTO godlessDTO)
    {
        if (godlessDTO == null)
        { 
            return BadRequest(godlessDTO);
        }

        //if(await _db.Gods.FirstOrDefaultAsync(god => god.Name.ToLower() == godlessDTO.Name.ToLower()) != null)
        //{
        //    ModelState.AddModelError("CustomError", "God is only one");

        //    return BadRequest();
        //}
        
        //if (godlessDTO.Id > 0)
        //{
        //    return StatusCode(StatusCodes.Status500InternalServerError);
        //}

        Godless newGod = new()
        {
            Name = godlessDTO.Name,
            Creation = godlessDTO.Creation
        };

        await _db.Gods.AddAsync(newGod);
        await _db.SaveChangesAsync();

        return CreatedAtRoute("GetGod", new {id = newGod.Id} , newGod);
    }


    [HttpDelete("{id:int}", Name = "RemoveGod")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveGod(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }
        var god = await _db.Gods.FirstOrDefaultAsync(g => g.Id == id); 

        if (god == null)
        {
            return NotFound();
        }

        _db.Gods.Remove(god);
        await _db.SaveChangesAsync();

        return NoContent();
    }


    [HttpPut("{id:int}", Name = "UpdateGod")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGod(int id, [FromBody]GodlessUpdateDTO god)
    {
        if (id != god.Id || god == null)
        {
            return BadRequest();
        }

        // The commented section is old way of update which does not counting on EF core magic bullshit
        // I am keeping this just in case that in future the EF Kokot Core will stop working once again

        //var update = _db.Gods.FirstOrDefault(x => x.Id == id);

        //if (update == null)
        //{
        //    return NotFound();
        //}

        //update.Name = god.Name;

        //_db.Entry(update).State = EntityState.Modified;


        // This should work but EF core is pile of shit
        // Now it suddenly works

        Godless newGod = new()
        {
            Name = god.Name,
            Id = god.Id
        };

        _db.Gods.Update(newGod);

        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("{id:int}", Name = "PatchGod")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PatchGod (int id, JsonPatchDocument<GodlessUpdateDTO> patch)
    {
        if (patch == null || id == 0)
        {
            return BadRequest();
        }

        // AsNoTracking means that EF CORE won't start to track this object after retrieving it from DB.

        var god = await _db.Gods.AsNoTracking().FirstOrDefaultAsync(obj => obj.Id == id);

        GodlessUpdateDTO gotPatch = new()
        {
            Id = god.Id,
            Name = god.Name
        };

        if(god == null)
        {
            return BadRequest();
        }

        patch.ApplyTo(gotPatch, ModelState);

        Godless patchedGod = new()
        {
            Id = gotPatch.Id,
            Name = gotPatch.Name
        };

        _db.Gods.Update(patchedGod);
        await _db.SaveChangesAsync();

        if(!ModelState.IsValid)
        {
            return BadRequest();
        }
        return NoContent();
    }
}
