using BadmintonReservationBusiness;
using BadmintonReservationData.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonReservationWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingBusiness _business;

        public BookingController(BookingBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _business.GetAllAsync();
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

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] CreateBookingRequestDTO bookingRequest)
        {
            var result = await _business.CreateBookingAsync(bookingRequest);
            return GenerateActionResult(result);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookingRequestDTO updateRequest)
        {
            var result = await _business.UpdateBookingAsync(id, updateRequest);
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _business.DeleteBookingAsync(id);
            return GenerateActionResult(result);
        }
    }
}