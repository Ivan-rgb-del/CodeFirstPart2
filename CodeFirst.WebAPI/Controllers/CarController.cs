using CodeFirst.Service.Interfaces;
using CodeFirst.Service.Repository;
using CodeFirstPart2.Model;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
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

        [HttpPost("car")]
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

            return View(carDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(int id, UpdateCarDto updateCar)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car != null)
            {
                car.Brand = updateCar.Brand;
                car.Model = updateCar.Model;
                car.Color = updateCar.Color;
                car.Year = updateCar.Year;
                car.Chassis = updateCar.Chassis;
                car.Number = updateCar.Number;

                _carRepository.UpdateCar(car);
                return Ok(car);
            }

            return NotFound();
        }

        [HttpDelete("car")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car != null)
            {
                _carRepository.DeleteCar(car);
                return Ok(car);
            }

            return NotFound();
        }
    }
}
