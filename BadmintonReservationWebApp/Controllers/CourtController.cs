using Microsoft.AspNetCore.Mvc;
using BadmintonReservationData;
using Newtonsoft.Json;
using BadmintonReservationData.DTO;
using System.Text;
using BadmintonReservationData.DTOs;
using BadmintonReservationWebApp.Models;

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

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("add", new CreateCourtDTO());
        }

        [HttpPost]
        public async Task<Court> Create([FromBody] CreateCourtDTO createCourtDTO)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(createCourtDTO);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(URL + "api/Court", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var court = JsonConvert.DeserializeObject<Court>(responseContent);
                            return court;
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
                UpdateCourtDTO result = null;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{URL}api/Court/GetById/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var courtResponse = JsonConvert.DeserializeObject<Court>(content);
                            result = new UpdateCourtDTO()
                            {
                                Id = courtResponse.Id,
                                Name = courtResponse.Name,
                                Status = courtResponse.Status
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
        public async Task<UpdateCourtDTO> Update([FromBody] UpdateCourtDTO udpateCourt)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(udpateCourt);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"{URL}api/Court/{udpateCourt.Id}", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var updatedFrame = JsonConvert.DeserializeObject<UpdateCourtDTO>(responseContent);
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
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{URL}api/Court/{id}");
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
                CourtReport result = null;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{URL}api/Court/GetById/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var courtResponse = JsonConvert.DeserializeObject<Court>(content);
                            result = new CourtReport()
                            {
                                Id = courtResponse.Id,
                                Name = courtResponse.Name,
                                Status = courtResponse.Status,
                                CreatedDate = courtResponse.CreatedDate,
                                UpdatedDate = courtResponse.UpdatedDate,
                            };
                        }
                    }

                    using (var response = await httpClient.GetAsync($"{URL}api/Frame/Court/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var frameResponse = JsonConvert.DeserializeObject<List<Frame>>(content);
                            if(frameResponse != null && frameResponse.Count > 0)
                            {
                                result.Frames = frameResponse;
                            }
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
}
