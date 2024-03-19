using CodeFirst.Service.Interfaces;
using CodeFirst.Service.Repository;
using CodeFirst.Validator;
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
        private readonly IEngineRepository _engineRepository;
        private readonly CarValidator _carValidator;

        public CarController(ICarRepository carRepository, IEngineRepository engineRepository, CarValidator carValidator)
        {
            _carRepository = carRepository;
            _engineRepository = engineRepository;
            _carValidator = carValidator;
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
                var existingEngine = await _engineRepository.GetByIdAsync(carDto.EngineId);
                if (existingEngine == null)
                {
                    return BadRequest("Invalid EngineId. Engine with this ID does not exist.");
                }

                var isValid = await _carValidator.ValidateCarAsync(carDto);
                if (!isValid)
                {
                    return BadRequest("The car model is not available for the given model and year.");
                }

                var newCar = new Car
                {
                    Brand = carDto.Brand,
                    Model = carDto.Model,
                    Color = carDto.Color,
                    Year = carDto.Year,
                    Chassis = carDto.Chassis,
                    Number = carDto.Number,
                    EngineId = carDto.EngineId,
                };

                _carRepository.CreateCar(newCar);
                return Ok(newCar);
            }

            return BadRequest(ModelState);
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
