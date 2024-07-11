using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadmintonReservationData;
using BadmintonReservationBusiness;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;
using BadmintonReservationData.DTOs;
using BadmintonReservationWebApp.Models;

namespace BadmintonReservationWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly string API_URL_ENDPOINT = "https://localhost:7257/api/";

        public CustomerController()
        {
        }

        [HttpGet]
        public async Task<List<Customer>> GetAll()
        {
            try
            {
                var result = new List<Customer>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{API_URL_ENDPOINT}Customer/"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<Customer>>(content);
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
