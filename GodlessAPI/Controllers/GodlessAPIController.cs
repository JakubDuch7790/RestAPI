using GodlessAPI.Data;
using GodlessAPI.Models;
using GodlessAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GodlessAPI.Controllers;
[Route("api/GodlessAPI")]
[ApiController]
public class GodlessAPIController : ControllerBase
{
    [HttpGet]
    public IEnumerable<GodlessDTO> GetGodless()
    {
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
}
