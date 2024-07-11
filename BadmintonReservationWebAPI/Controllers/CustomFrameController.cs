using BadmintonReservationBusiness;
using BadmintonReservationData.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonReservationWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomFrameController : ControllerBase
    {
        private CustomFrameBusiness _business;

        public CustomFrameController(CustomFrameBusiness customFrameBusiness)
        {
            _business = customFrameBusiness;
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

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCustomeFrame(CreateCustomFrameRequestDTO createCustomFrameRequest)
        {
            var result = await _business.CreateCustomFrame(createCustomFrameRequest);
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
        public async Task<IActionResult> UpdateCustomFrame(UpdateCustomFrameRequestDTO updateFrameRequest)
        {
            var result = await _business.UpdateCustomFrame(updateFrameRequest);
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
        public async Task<IActionResult> RemoveCustomFrame(int id)
        {
            var result = await _business.RemoveCustomFrame(id);
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
}
