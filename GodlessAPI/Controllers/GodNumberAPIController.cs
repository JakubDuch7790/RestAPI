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

    [HttpGet("{number:int}", Name = "GetGodByNumber")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<APIResponse>> GetGodByNumber(int number)
    {
        try
        {
            if (number == 0)
            {
                _logger.LogError($"Invalid number provided: {number} !");
                return BadRequest();
            }

            var god = await _dbContext.GetAsync(god => god.GodNo == number);

            if (god == null)
            {
                return NotFound();
            }

            _apiResponse.Result = _mapper.Map<GodNumberDTO>(god);
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult<APIResponse>> CreateGodNumber([FromBody] GodNumberCreatedDTO createDTO)
    {
        try
        {
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }

            GodNumber godToAdd = _mapper.Map<GodNumber>(createDTO);

            await _dbContext.CreateAsync(godToAdd);

            _apiResponse.Result = _mapper.Map<GodNumberDTO>(godToAdd);
            _apiResponse.StatusCode = HttpStatusCode.Created;

            return CreatedAtRoute("GetGodByNumber", new { number = godToAdd.GodNo }, _apiResponse);
        }
        catch (Exception ex)
        {
            _apiResponse.IsSuccessful = false;
            _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _apiResponse;
    }

    [HttpPut("{number:int}", Name = "UpdateGodNumber")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<APIResponse>> UpdateGodNumber(int number, [FromBody] GodNumberUpdatedDTO updateDTO)
    {
        try
        {
            if (number != updateDTO.GodNo || updateDTO == null)
            {
                return BadRequest();
            }

            GodNumber updatedGod = _mapper.Map<GodNumber>(updateDTO);

            await _dbContext.UpdateAsync(updatedGod);

            _apiResponse.StatusCode = HttpStatusCode.NoContent;
            _apiResponse.IsSuccessful = true;

            return Ok(_apiResponse);

        }
        catch (Exception ex)
        {
            _apiResponse.IsSuccessful = false;
            _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _apiResponse;
    }

    [HttpDelete("{number:int}", Name = "RemoveGodNumber")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<APIResponse>> RemoveGodNumber(int number)
    {
        try
        {
            if (number == 0)
            {
                return BadRequest();
            }
            var god = await _dbContext.GetAsync(g => g.GodNo == number);

            if (god == null)
            {
                return NotFound();
            }

            await _dbContext.RemoveAsync(god);

            _apiResponse.StatusCode = HttpStatusCode.NoContent;
            _apiResponse.IsSuccessful = true;

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
