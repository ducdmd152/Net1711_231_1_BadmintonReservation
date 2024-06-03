using System.Text;
using BadmintonReservationData;
using BadmintonReservationData.DTOs;
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
        return PartialView("Add", new CreateFrameRequestDTO());
    }

    [HttpGet]
    public async Task<List<Frame>> GetAll()
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
                    }
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<Frame> Create([FromBody] CreateFrameRequestDTO createFrameRequestDto)
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
                        return createdFrame;
                    }
                    else
                    {
                        throw new Exception(
                            $"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Internal server error: {ex.Message}");
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
                            TimeFrom = frameResponse.TimeFrom,
                            TimeTo = frameResponse.TimeTo,
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
    public async Task<Frame> Update([FromBody] UpdateFrameRequestDTO updateFrameRequestDto)
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
                        return updatedFrame;
                    }
                    else
                    {
                        throw new Exception(
                            $"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Internal server error: {ex.Message}");
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
}