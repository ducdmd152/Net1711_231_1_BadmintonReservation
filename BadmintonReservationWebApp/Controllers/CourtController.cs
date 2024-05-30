using Microsoft.AspNetCore.Mvc;
using BadmintonReservationData;
using Newtonsoft.Json;

namespace BadmintonReservationWebApp.Controllers
{
    public class CourtController : Controller
    {
        private const string URL = "https://localhost:7257/";

        // GET: Court
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        [HttpGet]
        public async Task<List<Court>> GetAll()
        {
            try
            {
                var result = new List<Court>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(URL + "api/Court/GetAll"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<Court>>(content);
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
}
