using System.Text;
using BadmintonReservationBusiness;
using BadmintonReservationData;
using BadmintonReservationData.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BadmintonReservationWebApp.Controllers;

public class DateTypeController : Controller
{
    private readonly string API_URL_ENDPOINT = "https://localhost:7257/api/DateType";

    public DateTypeController()
    {
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
    [HttpGet]
    public async Task<List<DateType>> GetAll()
    {
        try
        {
            var result = new List<DateType>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(API_URL_ENDPOINT + "/GetAll"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<DateType>>(content);
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
}