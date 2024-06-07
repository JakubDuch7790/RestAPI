using AutoMapper;
using GodlessAPI.Data;
using GodlessAPI.Models;
using GodlessAPI.Models.Dto;
using GodlessAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GodlessAPI.Controllers;
[Route("api/GodlessAPI")]
[ApiController]
public class GodlessAPIController : ControllerBase
{
    private readonly ILogger<GodlessAPIController> _logger;
    private readonly IMapper _mapper;
    private readonly IGodRepository _dbContext;

    public GodlessAPIController(ILogger<GodlessAPIController> logger, IGodRepository dbContext, IMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GodlessDTO>>> GetGods()
    {
        IEnumerable<Godless> godsList = await _dbContext.GetAllAsync();

        return  Ok(_mapper.Map<List<GodlessDTO>>(godsList));
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

        var god = await _dbContext.GetAsync(god => god.Id == id);

        if(god == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<GodlessDTO>(god));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GodlessDTO>> CreateGod([FromBody] GodlessCreatedDTO createDTO)
    {
        if (createDTO == null)
        { 
            return BadRequest(createDTO);
        }

        //This validation return 400

        //if(await _db.Gods.FirstOrDefaultAsync(god => god.Name.ToLower() == godlessDTO.Name.ToLower()) != null)
        //{
        //    ModelState.AddModelError("CustomError", "God is only one");

        //    return BadRequest();
        //}
        
        //Since we are using multiple DTOs, this is redundant

        //if (godlessDTO.Id > 0)
        //{
        //    return StatusCode(StatusCodes.Status500InternalServerError);
        //}


        Godless godToAdd = _mapper.Map<Godless>(createDTO);

        //We are using AutoMapper instead of this:

        //Godless newGod = new()
        //{
        //    Name = createDTO.Name,
        //    Creation = createDTO.Creation
        //};
        await _dbContext.CreateAsync(godToAdd);

        return CreatedAtRoute("GetGod", new {id = godToAdd.Id} , godToAdd);
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
        var god = await _dbContext.GetAsync(g => g.Id == id); 

        if (god == null)
        {
            return NotFound();
        }

        await _dbContext.RemoveAsync(god);

        return NoContent();
    }


    [HttpPut("{id:int}", Name = "UpdateGod")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGod(int id, [FromBody]GodlessUpdateDTO updateDTO)
    {
        if (id != updateDTO.Id || updateDTO == null)
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

        Godless updatedGod = _mapper.Map<Godless>(updateDTO);

        //Godless newGod = new()
        //{
        //    Name = updateDTO.Name,
        //    Id = updateDTO.Id
        //};

        await _dbContext.UpdateAsync(updatedGod);

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

        var god = await _dbContext.GetAsync(obj => obj.Id == id, tracked:false);

        GodlessUpdateDTO godlessUpdateDTO = _mapper.Map<GodlessUpdateDTO>(god);

        //GodlessUpdateDTO gotPatch = new()
        //{
        //    Id = god.Id,
        //    Name = god.Name
        //};

        if(god == null)
        {
            return BadRequest();
        }

        patch.ApplyTo(godlessUpdateDTO, ModelState);

        Godless patchedGod = _mapper.Map<Godless>(godlessUpdateDTO);

        //Godless patchedGod = new()
        //{
        //    Id = gotPatch.Id,
        //    Name = gotPatch.Name
        //};

        await _dbContext.UpdateAsync(patchedGod);

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        return NoContent();
    }
}
