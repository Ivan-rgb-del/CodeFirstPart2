using CodeFirst.Service.Interfaces;
using CodeFirst.Service.Repository;
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

        //[HttpGet("engines")]
        //public async Task<IActionResult> GetEngines()
        //{
        //    var engine = await _engineRepository.GetEngines();
        //    return Ok(engine);
        //}

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
                    Type = engineDto.Type,
                };

                _engineRepository.CreateEngine(engine);
                return Ok(engine);
            }

            return View(engineDto);
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateEngine(int id, UpdateEngineDto updateEngineDto)
        //{
        //    var engine = await _engineRepository.GetByIdAsync(id);
        //    if (engine != null)
        //    {
        //        engine.Year = updateEngineDto.Year;
        //        engine.MyProperty = updateEngineDto.MyProperty;
        //        engine.SerialNumber = updateEngineDto.SerialNumber;
        //        engine.Type = updateEngineDto.Type;

        //        _engineRepository.UpdateEngine(engine);
        //        return Ok(engine);
        //    }

        //    return NotFound();
        //}

        //[HttpDelete("engine")]
        //public async Task<IActionResult> DeleteEngine(int id)
        //{
        //    var engine = await _engineRepository.GetByIdAsync(id);
        //    if (engine != null)
        //    {
        //        _engineRepository.DeleteEngine(engine);
        //        return Ok(engine);
        //    }

        //    return NotFound();
        //}
    }
}
