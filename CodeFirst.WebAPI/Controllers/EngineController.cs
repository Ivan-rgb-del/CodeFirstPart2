using CodeFirst.Service.Interfaces;
using CodeFirstPart2.Model;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : Controller
    {
        private readonly IEngineRepository _engineRepository;

        public EngineController(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }

        [HttpPost("engine")]
        public async Task<IActionResult> AddEngine(CreateEngineDto engineDto)
        {
            if (ModelState.IsValid)
            {
                var engine = new Engine
                {
                    Year = engineDto.Year,
                    MyProperty = engineDto.MyProperty,
                    SerialNumber = engineDto.SerialNumber,
                    Type = engineDto.Type
                };

                _engineRepository.CreateEngine(engine);
                return Ok(engine);
            }

            return View(engineDto);
        }
    }
}
