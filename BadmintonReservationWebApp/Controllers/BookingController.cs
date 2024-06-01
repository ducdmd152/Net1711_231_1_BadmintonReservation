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

namespace BadmintonReservationWebApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly string API_URL_ENDPOINT = "https://localhost:7257/api/Booking/";
        
        public BookingController()
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("add", new Booking());
        }

        [HttpGet]
        public async Task<List<Booking>> GetAll()
        {
            try
            {
                var result = new List<Booking>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(API_URL_ENDPOINT))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<Booking>>(content);
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

        [HttpGet("{id}")]
        public async Task<Booking> Details(int id)
        {
            try
            {
                Booking result = null;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(API_URL_ENDPOINT))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<Booking>(content);
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
        public async Task<Booking> Create(int id, [FromBody] Booking booking)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(booking);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{API_URL_ENDPOINT}", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var createdBooking = JsonConvert.DeserializeObject<Booking>(responseContent);
                            return createdBooking;
                        }
                        else
                        {
                            throw new Exception($"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<Booking> Update(int id, [FromBody] UpdateBookingRequestDTO updateBookingRequest)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(updateBookingRequest);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"{API_URL_ENDPOINT}{id}", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var updatedBooking = JsonConvert.DeserializeObject<Booking>(responseContent);
                            return updatedBooking;
                        }
                        else
                        {
                            throw new Exception($"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}");
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
