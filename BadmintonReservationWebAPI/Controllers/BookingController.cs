using BadmintonReservationBusiness;
using BadmintonReservationData.DTO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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
        public async Task<IActionResult> GetAll(
            int pageIndex = 1,
            int pageSize = 4,
            string? searchText = "",
            int status = 0,
            int paymentType = 0,
            int paymentStatus = 0,
            int bookingType = 0,
            DateTime? bookingDateFrom = null,
            DateTime? bookingDateTo = null)
        {
            var filterDTO = new BookingFilterDTO
            {
                SearchText = searchText ?? "",
                Status = status,
                PaymentType = paymentType,
                PaymentStatus = paymentStatus,
                BookingType = bookingType,
                BookingDateFrom = bookingDateFrom,
                BookingDateTo = bookingDateTo
            };

            var result = await _business.GetAllWithFilterWithDetailsAsync(pageIndex, pageSize, filterDTO);
            return GenerateActionResult(result);
        }



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _business.GetByIdAsync(id);
            return GenerateActionResult(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] CreateBookingRequestDTO bookingRequest)
        {
            var result = await _business.CreateBookingAsync(bookingRequest);
            return GenerateActionResult(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePutBookingRequestDTO updateRequest)
        {
            var result = await _business.UpdateBookingAsync(id, updateRequest);
            return GenerateActionResult(result);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateByPatch(int id, [FromBody] UpdatePatchBookingRequestDTO updateRequest)
        {
            var result = await _business.UpdateByPatchBookingAsync(id, updateRequest);
            return GenerateActionResult(result);
        }        

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _business.DeleteBookingAsync(id);
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
                    return Ok(result.Data);
                case 201:
                    return StatusCode(201, result.Data);
                default:
                    return StatusCode(500, "An internal server error occurred. Please try again later.");
            }
        }
    }
}