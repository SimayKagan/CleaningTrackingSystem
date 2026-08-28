using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CleaningTracking.Business.Abstract;
using CleaningTracking.Business.DTO;

namespace CleaningTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        public BuildingsController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _buildingService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _buildingService.GetByIdAsync(id);
            if (result == null) return NotFound("Bina Bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public async Task <IActionResult> Create([FromBody] CreateBuildingDTO dto)
        {

            var result = await _buildingService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBuildingDTO dto)
        {
            var result = await _buildingService.UpdateAsync(dto);
            if (!result) return NotFound("Güncellenecek Bina Bulunamadı.");
            return Ok("Bina Başarıyla Güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _buildingService.DeleteAsync(id);
            if (!result) return NotFound("Silinecek Bina Bulunamadı.");
            return Ok("Bina Başarıyla Silindi");
        }
    }
}
