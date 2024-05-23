using BadmintonReservationBusiness;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonReservationWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourtController : ControllerBase
    {
        private readonly CourtBusiness _business;

        public CourtController()
        {
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
                    break;
                case 404:
                    return NotFound(result);
                    break;
                case 200:
                    return Ok(result);
                    break;
                default:
                    return StatusCode(500, "An internal server error occurred. Please try again later.");
                    break;
            }                
        }

        [HttpGet]
        [Route("GetById")]
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
                default:
                    return StatusCode(500, "An internal server error occurred. Please try again later.");
                    break;
            }
        }
    }
}