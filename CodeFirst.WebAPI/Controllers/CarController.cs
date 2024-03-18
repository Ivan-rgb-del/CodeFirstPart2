using CodeFirst.Service.Interfaces;
using CodeFirst.Service.Repository;
using CodeFirstPart2.Model;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CodeFirst.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("cars")]
        public async Task<IActionResult> AllCars()
        {
            var cars = await _carRepository.GetCars();
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CreateCarDto carDto)
        {
            if (ModelState.IsValid)
            {
                var car = new Car
                {
                    Brand = carDto.Brand,
                    Model = carDto.Model,
                    Color = carDto.Color,
                    Year = carDto.Year,
                    Chassis = carDto.Chassis,
                    Number = carDto.Number,
                };

                _carRepository.CreateCar(car);
                return Ok(car);
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(carDto);
        }

        [HttpDelete("car")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);
            if (carDetails == null) return View("Error");

            _carRepository.DeleteCar(carDetails);

            return NoContent();
        }
    }
}
