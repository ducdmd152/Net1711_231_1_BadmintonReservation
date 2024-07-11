using BadmintonReservationBusiness;
using BadmintonReservationData;
using BadmintonReservationData.DTO;
using BadmintonReservationData.DTOs;
using BadmintonReservationWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonReservationWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourtController : ControllerBase
    {
        private readonly CourtBusiness _business;

        public CourtController(CourtBusiness business)
        {
            this._business = business;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] CourtSearchConditionDTO condition)
        {
            var result = await _business.GetAllWithCondition(condition);
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

        [HttpGet]
        [Route("GetById/{id}")]
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
                    return Ok(result.Data);
                    break;
                default:
                    return StatusCode(500, "An internal server error occurred. Please try again later.");
                    break;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourt(CreateCourtDTO courtRequest)
        {
            var result = await _business.CreateCourt(courtRequest);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourt(UpdateCourtDTO courtRequest)
        {
            var result = await _business.UpdateCourt(courtRequest);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCourt(int id)
        {
            var result = await _business.RemoveCourt(id);
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