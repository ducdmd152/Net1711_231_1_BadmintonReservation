using BadmintonReservationData;
using BadmintonReservationData.DTO;
using BadmintonReservationData.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BadmintonReservationWebApp.Controllers;

public class PurchasedController : Controller
{
    private readonly string API_URL_ENDPOINT = "https://localhost:7257/api/Purchased";

    public PurchasedController()
    {
    }


    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Add()
    {
        return PartialView("Add", new CreatePurchasedRequestDTO());
    }

    [HttpGet]
    public async Task<IActionResult> Report(int id)
    {
        try
        {
            PurchasedHoursMonthly result = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{API_URL_ENDPOINT}/GetById/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<PurchasedHoursMonthly>(content);
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

    //[HttpGet]
    //public async Task<List<PurchasedHoursMonthly>> GetAll()
    //{
    //    try
    //    {
    //        var result = new List<PurchasedHoursMonthly>();
    //        using (var httpClient = new HttpClient())
    //        {
    //            using (var response = await httpClient.GetAsync(API_URL_ENDPOINT + "/GetAll"))
    //            {
    //                if (response.IsSuccessStatusCode)
    //                {
    //                    var content = await response.Content.ReadAsStringAsync();
    //                    result = JsonConvert.DeserializeObject<List<PurchasedHoursMonthly>>(content);
    //                }
    //            }
    //        }

    //        return result;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}

    [HttpGet]
    public async Task<IActionResult> GetAll(
        int pageIndex = 1,
        int pageSize = 4,
        string? searchText = "",
        int status = 0,
        int amountHour = 0)
    {
        try
        {
            var result = new PageableResponseDTO<PurchasedHoursMonthly>();
            using (var httpClient = new HttpClient())
            {
                var queryParams = new List<string>();

                queryParams.Add($"pageIndex={Uri.EscapeDataString(pageIndex.ToString())}");
                queryParams.Add($"pageSize={Uri.EscapeDataString(pageSize.ToString())}");

                if (!string.IsNullOrEmpty(searchText))
                    queryParams.Add($"searchText={Uri.EscapeDataString(searchText)}");
                else
                    queryParams.Add($"searchText={Uri.EscapeDataString("")}");


                if (amountHour != 0)
                    queryParams.Add($"amountHour={amountHour}");
                if (status != 0)
                    queryParams.Add($"status={status}");

                var queryString = string.Join("&", queryParams);

                var requestUrl = $"{API_URL_ENDPOINT}/GetAll";
                if (!string.IsNullOrEmpty(queryString))
                    requestUrl = $"{requestUrl}?{queryString}";

                using (var response = await httpClient.GetAsync(requestUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<PageableResponseDTO<PurchasedHoursMonthly>>(content);
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
    public async Task<PurchasedHoursMonthly> Create([FromBody] CreatePurchasedRequestDTO createPurchasedRequestDto)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(createPurchasedRequestDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(API_URL_ENDPOINT + "/Create", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var createdPurchased = JsonConvert.DeserializeObject<PurchasedHoursMonthly>(responseContent);
                        return createdPurchased;
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

    [HttpPut]
    public async Task<PurchasedHoursMonthly> Update([FromBody] UpdatePurchasedRequestDTO updatePurchasedRequestDto)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(updatePurchasedRequestDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync($"{API_URL_ENDPOINT}/Update", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var updatedPurchased = JsonConvert.DeserializeObject<PurchasedHoursMonthly>(responseContent);
                        return updatedPurchased;
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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        try
        {
            UpdatePurchasedRequestDTO result = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{API_URL_ENDPOINT}/GetById/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var purchasedResponse = JsonConvert.DeserializeObject<PurchasedResponseDTO>(content);
                        result = new UpdatePurchasedRequestDTO()
                        {
                            Id = purchasedResponse.Id,
                            AmountHour = purchasedResponse.AmountHour,
                            Status = purchasedResponse.Status,
                            CustomerId = purchasedResponse.CustomerId,
                            PaymentId = purchasedResponse.PaymentId,
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

}
