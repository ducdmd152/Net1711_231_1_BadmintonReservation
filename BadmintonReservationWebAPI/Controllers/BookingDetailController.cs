using BadmintonReservationBusiness;
using BadmintonReservationData.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonReservationWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingDetailController : ControllerBase
    {
        private readonly BookingDetailBusiness _business;

        public BookingDetailController()
        {
            _business = new BookingDetailBusiness();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _business.GetByIdAsync(id);
            switch (result.Status)
            {
                case 400:
                    return BadRequest(result);
                    break;
                case 404:
                    return NotFound(result);
                    break;
                case 200:
                    return Ok(result);
                    break;
                case 201:
                    return StatusCode(201, result);
                default:
                    return StatusCode(500, "An internal server error occurred. Please try again later.");
                    break;
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookingDetailRequestDTO updateRequest)
        {
            var result = await _business.UpdateBookingDetailAsync(id, updateRequest);
            return GenerateActionResult(result);
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
                    return Ok(result);
                case 201:
                    return StatusCode(201, result);
                default:
                    return StatusCode(500, "An internal server error occurred. Please try again later.");
            }
        }
    }
}