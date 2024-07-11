using BadmintonReservationBusiness;
using BadmintonReservationData.DTO;
using BadmintonReservationData.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonReservationWebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PurchasedController : ControllerBase
{
    private readonly PurchasedBusiness _business;

    public PurchasedController(PurchasedBusiness business)
    {
        _business = business;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll(
            int pageIndex = 1,
            int pageSize = 4,
            string? searchText = "",
            int status = 0,
            int amountHour = 0)
    {
        var filterDTO = new PurchasedFilterDTO
        {
            SearchText = searchText ?? "",
            Status = status,
            AmountHour = amountHour,
        };

        var result = await _business.GetAllWithFilterWithAsync(pageIndex, pageSize, filterDTO);
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
        var result = await _business.GetPurchasedById(id);
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
    public async Task<IActionResult> CreatePurchased(CreatePurchasedRequestDTO createPurchasedRequest)
    {
        var result = await _business.CreatePurchased(createPurchasedRequest);
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
    public async Task<IActionResult> UpdatePurchased(UpdatePurchasedRequestDTO updatePurchasedRequest)
    {
        var result = await _business.UpdatePurchased(updatePurchasedRequest);
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
    public async Task<IActionResult> RemovePurchased(int id)
    {
        var result = await _business.RemovePurchased(id);
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
}
