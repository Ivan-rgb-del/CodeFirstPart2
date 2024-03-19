using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Azure;

namespace CodeFirstPart2.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Chassis { get; set; }
        public int Number { get; set; }

        public int EngineId { get; set; }
        public Engine? Engine { get; set; }
    }

    //public class CarValidationService
    //{
    //    private readonly HttpClient _httpClient;

    //    public CarValidationService(HttpClient httpClient)
    //    {
    //        _httpClient = httpClient;
    //    }

    //    public async Task<bool> IsModelAvailable(string model, int year)
    //    {
    //        try
    //        {
    //            HttpResponseMessage response2 = await _httpClient.GetAsync($"https://car-api2.p.rapidapi.com/api/{model}?sort=id&direction=asc&year={year}&verbose=yes");

    //            if (response2.IsSuccessStatusCode)
    //            {
    //                string responseBody = await response2.Content.ReadAsStringAsync();
    //                if (responseBody.Contains("model_available\":true"))
    //                {
    //                    return true;
    //                }
    //                else
    //                {
    //                    return false;
    //                }
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            await Console.Out.WriteLineAsync($"Error message in communication with API: {ex}");
    //            return false;
    //        }
    //    }
    //}

    //public class CarValidator
    //{
    //    private readonly CarValidationService _carValidationService;

    //    public CarValidator(CarValidationService carValidationService)
    //    {
    //        _carValidationService = carValidationService;
    //    }

    //    public async Task<bool> ValidateCar(Car car)
    //    {
    //        return await _carValidationService.IsModelAvailable(car.Model, car.Year);
    //    }
    //}
}
