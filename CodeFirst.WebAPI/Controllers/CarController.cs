using CodeFirst.Service.Interfaces;
using CodeFirst.Service.Repository;
using CodeFirstPart2.Model;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("cars")]
        public IActionResult AddCar(Car car)
        {
            _carRepository.CreateCar(car);
            _carRepository.Save();

            return Ok(car);
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
