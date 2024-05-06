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
    public GodlessDTO GetGod(int id)
    {
        return GodlessStore.GodlessList.FirstOrDefault(god => god.Id == id);
    }
}
