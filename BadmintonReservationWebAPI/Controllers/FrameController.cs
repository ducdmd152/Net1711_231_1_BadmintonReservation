using BadmintonReservationBusiness;
using BadmintonReservationData.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonReservationWebAPI.Controllers
{
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
        [Route("court/{id}/available")]
        public async Task<IActionResult> GetAllFrameAvailableOfCourtForDate(int id)
        {
            var result = await _business.GetAllFrameAvailableOfCourtForDate(id, DateTime.Now);
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