using CodeFirst.Service.Interfaces;
using CodeFirstPart2.Model.CarApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Service.Services
{
    public class CarValidationService : ICarValidationService
    {
        private readonly HttpClient _httpClient;

        public CarValidationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "car-api2.p.rapidapi.com");
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "8a3b410875msh66bf17a53266704p1aa927jsnb6bf7ec0ed09");
        }

        public async Task<bool> IsModelAvailableAsync(string model, int year)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://car-api2.p.rapidapi.com/api/models?sort=id&direction=asc&year={year}&verbose=yes"),
            };

            request.Headers.Add("X-RapidAPI-Key", "8a3b410875msh66bf17a53266704p1aa927jsnb6bf7ec0ed09");
            request.Headers.Add("X-RapidAPI-Host", "car-api2.p.rapidapi.com");

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<CarApiResponse>(body);

                return apiResponse.Data.Any(d => d.Name.Equals(model, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
