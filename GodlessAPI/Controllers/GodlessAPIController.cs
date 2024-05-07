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

    [HttpGet("{id:int}")]
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
}
