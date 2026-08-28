using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CleaningTracking.Business.Abstract;
using CleaningTracking.Business.DTO;

namespace CleaningTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorsController : ControllerBase
    {
        private readonly IFloorService _floorService;
        public FloorsController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _floorService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _floorService.GetByIdAsync(id);
            if (result == null) return NotFound("Kat Bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFloorDTO dto)
        {
            var result = await _floorService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFloorDTO dto)
        {
            var result = await _floorService.UpdateAsync(dto);
            if (!result) return NotFound("Güncellenecek Kat Bulunamadı.");
            return Ok("Kat Başarıyla Güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _floorService.DeleteAsync(id);
            if (!result) return NotFound("Silinecek Kat Bulunamadı.");
            return Ok("Kat Başarıyla Silindi");
        }
    }
}
