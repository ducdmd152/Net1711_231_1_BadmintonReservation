using BadmintonReservationBusiness;
using BadmintonReservationData.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonReservationWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FrameController : ControllerBase
{
    private readonly FrameBusiness _business;

    public FrameController(FrameBusiness business)
    {
        _business = business;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _business.GetAll();
        switch (result.Status)
        {
            case 400:
                return BadRequest(result);
            case 404:
                return NotFound(result);
            case 200:
                return Ok(result.Data);
            default:
                return StatusCode(500, "An internal server error occurred. Please try again later.");
        }
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _business.GetById(id);
        switch (result.Status)
        {
            case 400:
                return BadRequest(result);
            case 404:
                return NotFound(result);
            case 200:
                return Ok(result.Data);
            default:
                return StatusCode(500, "An internal server error occurred. Please try again later.");
        }
    }

    [HttpGet]
    [Route("GetByIdIncludeCourt/{id}")]
    public async Task<IActionResult> GetByIdIncludeCourt(int id)
    {
        var result = await _business.GetByIdIncludeCourt(id);
        switch (result.Status)
        {
            case 400:
                return BadRequest(result);
            case 404:
                return NotFound(result);
            case 200:
                return Ok(result.Data);
            default:
                return StatusCode(500, "An internal server error occurred. Please try again later.");
        }
    }

    
    
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateFrame(CreateFrameRequestDTO createFrameRequest)
    {
        var result = await _business.CreateFrame(createFrameRequest);
        switch (result.Status)
        {
            case 400:
                return BadRequest(result);
            case 404:
                return NotFound(result);
            case 200:
                return Ok(result);
            default:
                return StatusCode(500, "An internal server error occurred. Please try again later.");
        }
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateFrame(UpdateFrameRequestDTO updateFrameRequest)
    {
        var result = await _business.UpdateFrame(updateFrameRequest);
        switch (result.Status)
        {
            case 400:
                return BadRequest(result);
            case 404:
                return NotFound(result);
            case 200:
                return Ok(result);
            default:
                return StatusCode(500, "An internal server error occurred. Please try again later.");
        }
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> RemoveFrame(int id)
    {
        var result = await _business.RemoveFrame(id);
        switch (result.Status)
        {
            case 400:
                return BadRequest(result);
            case 404:
                return NotFound(result);
            case 200:
                return Ok(result);
            default:
                return StatusCode(500, "An internal server error occurred. Please try again later.");
        }
    }

    private IActionResult GenerateActionResult(IBusinessResult result)
    {
        switch (result.Status)
        {
            case 400:
                return BadRequest(result);
            case 404:
                return NotFound(result);
            case 200:
                return Ok(result.Data);
            case 201:
                return StatusCode(201, result.Data);
            default:
                return StatusCode(500, "An internal server error occurred. Please try again later.");
        }
    }

    [HttpGet]
    [Route("available")]
    public async Task<IActionResult> GetAllFrameAvailableForDate([FromQuery] DateTime bookingDate)
    {
        var result = await _business.GetAllFrameAvailableForDate(bookingDate);
        return GenerateActionResult(result);
    }

    [HttpGet]
    [Route("court/{id}/available")]
    public async Task<IActionResult> GetAllFrameAvailableOfCourtForDate(int id, [FromQuery] DateTime bookingDate)
    {
        var result = await _business.GetAllFrameAvailableOfCourtForDate(id, bookingDate);
        return GenerateActionResult(result);
    }

    [HttpGet]
    [Route("Court/{id}")]
    public IActionResult GetAllFrameWithCourtId(int id)
    {
        var result = this._business.GetAllFrameWithCourtId(id);
        return Ok(result);
    }
}