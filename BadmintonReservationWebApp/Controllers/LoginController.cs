using BadmintonReservationData;
using BadmintonReservationData.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;

namespace BadmintonReservationWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly string API_URL_ENDPOINT = "https://localhost:7257/api/";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<Customer> Login([FromBody] LoginDTO login)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(login);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{API_URL_ENDPOINT}Customer/Login", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            HttpContext.Session.SetString("CREDENTIAL", "Login");
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var customer = JsonConvert.DeserializeObject<Customer>(responseContent);
                            return customer;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Internal server error: {ex.Message}");
            }
        }
    }
}
