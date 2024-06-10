using System.Net;
using System.Text;
using BadmintonReservationBusiness;
using BadmintonReservationData;
using BadmintonReservationData.DTOs;
using BadmintonReservationData.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BadmintonReservationWebApp.Controllers;

public class FrameController : Controller
{
    private readonly string API_URL_ENDPOINT = "https://localhost:7257/api/Frame";

    public FrameController()
    {
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Add()
    {
        return PartialView("Add", new CreateFrameRequestDTO
        {
            TimeFrom = 600,
            TimeTo = 700
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = new List<Frame>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(API_URL_ENDPOINT + "/GetAll"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<Frame>>(content);
                        return Ok(result);
                    }
                    else
                    {
                        var errorMessage = $"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}";
                        return StatusCode((int)response.StatusCode, errorMessage);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFrameRequestDTO createFrameRequestDto)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(createFrameRequestDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(API_URL_ENDPOINT + "/Create", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var createdFrame = JsonConvert.DeserializeObject<Frame>(responseContent);
                        return Ok(createdFrame);
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var errorMessage = JsonConvert.DeserializeObject<BusinessResult>(await response.Content.ReadAsStringAsync()).Message;
                        return BadRequest(errorMessage);
                    }
                    else
                    {
                        var errorMessage = $"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}";
                        return StatusCode((int)response.StatusCode, errorMessage);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        try
        {
            UpdateFrameRequestDTO result = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{API_URL_ENDPOINT}/GetById/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var frameResponse = JsonConvert.DeserializeObject<FrameResponseDTO>(content);
                        result = new UpdateFrameRequestDTO()
                        {
                            Id = frameResponse.Id,
                            TimeFrom = TimeConverter.ConvertToTimeSpan(frameResponse.TimeFrom),
                            TimeTo = TimeConverter.ConvertToTimeSpan(frameResponse.TimeTo),
                            Price = frameResponse.Price,
                            CourtId = frameResponse.CourtId,
                            Status = frameResponse.Status
                        };
                    }
                }
            }

            return PartialView("edit", result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFrameRequestDTO updateFrameRequestDto)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(updateFrameRequestDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync($"{API_URL_ENDPOINT}/Update", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var updatedFrame = JsonConvert.DeserializeObject<Frame>(responseContent);
                        return Ok(updatedFrame);
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var errorMessage = JsonConvert.DeserializeObject<BusinessResult>(await response.Content.ReadAsStringAsync()).Message;
                        return BadRequest(errorMessage);
                    }
                    else
                    {
                        var errorMessage = $"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}";
                        return StatusCode((int)response.StatusCode, errorMessage);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"{API_URL_ENDPOINT}/Delete/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Report(int id)
    {
        try
        {
            Frame result = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{API_URL_ENDPOINT}/GetByIdIncludeCourt/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<Frame>(content);
                    }
                }
            }

            return View("report", result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}