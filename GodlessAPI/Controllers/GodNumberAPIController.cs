using AutoMapper;
using GodlessAPI.Models;
using GodlessAPI.Models.Dto;
using GodlessAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GodlessAPI.Controllers;

[Route("api/GodsNumberAPI")]
[ApiController]
public class GodNumberAPIController : ControllerBase
{
    protected APIResponse _apiResponse;

    private readonly ILogger<GodNumberAPIController> _logger;
    private readonly IMapper _mapper;
    private readonly IGodNumberRepository _dbContext;

    public GodNumberAPIController(ILogger<GodNumberAPIController> logger, IGodNumberRepository dbContext, IMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;

        this._apiResponse = new();

    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<APIResponse>> GetGodsNumber()
    {
        try
        {
            _logger.LogInformation("Calling GetGodsNumber");

            IEnumerable<GodNumber> godsNumberList = await _dbContext.GetAllAsync();

            _apiResponse.Result = _mapper.Map<List<GodNumberDTO>>(godsNumberList);
            _apiResponse.StatusCode = HttpStatusCode.OK;

            return Ok(_apiResponse);

        }
        catch (Exception ex)
        {
            _apiResponse.IsSuccessful = false;
            _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _apiResponse;
    }

}
