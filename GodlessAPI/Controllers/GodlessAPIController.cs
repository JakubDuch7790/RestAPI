using GodlessAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodlessAPI.Controllers;
[Route("api/GodlessAPI")]
[ApiController]
public class GodlessAPIController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Godless> GetGodless()
    {
        return new List<Godless>
        {
            new Godless { Id = 1, Name = "Thor"},
            new Godless { Id = 2, Name = "Odin"}
        };
    }
}
