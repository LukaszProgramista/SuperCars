using Microsoft.AspNetCore.Mvc;
using SuperCarAPI.Models;
using SuperCarAPI.Services.SuperCarService;

namespace SuperCarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperCarController : ControllerBase
    {
        private readonly ISuperCarService _superCarService;
        public SuperCarController(ISuperCarService superCarService)
        {
            _superCarService = superCarService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperCar>>> GetAllCars()
        {
            return await _superCarService.GetAllCars();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleCar(int id)
        {
            var result = await _superCarService.GetOneCar(id);
            if (result is null) { return NotFound("Car not found"); }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] SuperCar car)
        {
            var result = await _superCarService.AddCar(car);
            if (result is null) { return NotFound("Car not found"); }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(int id, SuperCar request)
        {
            var result = await _superCarService.UpdateCar(id, request);
            if (result is null) { return NotFound("Car not found"); }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var result = await _superCarService.DeleteCar(id);
            if (result is null) { return NotFound("Car not found"); }
            return Ok(result);
        }
    }
}
