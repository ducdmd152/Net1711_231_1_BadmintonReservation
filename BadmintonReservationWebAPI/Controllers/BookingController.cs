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

        public BookingController()
        {
            _business = new BookingBusiness();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _business.GetAll();
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
            var result = await _business.GetById(id);
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
            var result = await _business.CreateBooking(bookingRequest);
            return GenerateActionResult(result);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookingRequestDTO updateRequest)
        {
            var result = await _business.UpdateBooking(id, updateRequest);
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