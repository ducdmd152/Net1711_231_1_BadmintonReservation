using BadmintonReservationBusiness;
using BadmintonReservationData.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonReservationWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DateTypeController : ControllerBase
    {
        private readonly DateTypeBusiness _business;

        public DateTypeController(DateTypeBusiness business)
        {
            this._business = business;
        }

        [HttpGet]
        [Route("GetAll")]
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
                    return Ok(result.Data);
                    break;
                default:
                    return StatusCode(500, "An internal server error occurred. Please try again later.");
                    break;
            }
        }
    }
}