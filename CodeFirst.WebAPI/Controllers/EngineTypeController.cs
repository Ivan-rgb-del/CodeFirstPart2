using CodeFirst.Service.Interfaces;
using CodeFirst.Service.Repository;
using CodeFirstPart2.Model;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineTypeController : Controller
    {
        private readonly IEngineTypeRepository _engineTypeRepository;

        public EngineTypeController(IEngineTypeRepository engineTypeRepository)
        {
            _engineTypeRepository = engineTypeRepository;
        }

        [HttpGet("engine-types")]
        public async Task<IActionResult> AllEngineTypes()
        {
            var engineTypes = await _engineTypeRepository.GetEngineTypes();
            return Ok(engineTypes);
        }

        [HttpPost("engine-type")]
        public async Task<IActionResult> AddEngineType(CreateEngineTypeDto engineTypeDto)
        {
            if (ModelState.IsValid)
            {
                var engineType = new EngineType
                {
                    Model = engineTypeDto.Model,
                    Name = engineTypeDto.Name
                };

                _engineTypeRepository.CreateEngineType(engineType);
                return Ok(engineType);
            }

            return View(engineTypeDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEngineType(int id, UpdateEngineTypeDto updateEngineType)
        {
            var engineType = await _engineTypeRepository.GetByIdAsync(id);
            if (engineType != null)
            {
                engineType.Model = updateEngineType.Model;
                engineType.Name = updateEngineType.Name;

                _engineTypeRepository.UpdateEngineType(engineType);
                return Ok(engineType);
            }

            return NotFound();
        }

        [HttpDelete("car")]
        public async Task<IActionResult> DeleteEngineType(int id)
        {
            var engineType = await _engineTypeRepository.GetByIdAsync(id);
            if (engineType != null)
            {
                _engineTypeRepository.DeleteEngineType(engineType);
                return Ok(engineType);
            }

            return NotFound();
        }
    }
}
