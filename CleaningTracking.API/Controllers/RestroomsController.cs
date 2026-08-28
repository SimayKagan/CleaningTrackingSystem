using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CleaningTracking.Business.Abstract;
using CleaningTracking.Business.DTO;

namespace CleaningTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestroomsController : ControllerBase
    {
        private readonly IRestroomService _restroomService;
        public RestroomsController(IRestroomService restroomService)
        {
            _restroomService = restroomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _restroomService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _restroomService.GetByIdAsync(id);
            if (result == null) return NotFound("Tuvalet Bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRestroomDTO dto)
        {
            var result = await _restroomService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRestroomDTO dto)
        {
            var result = await _restroomService.UpdateAsync(dto);
            if (!result) return NotFound("Güncellenecek Tuvalet Bulunamadı.");
            return Ok("Tuvalet Başarıyla Güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _restroomService.DeleteAsync(id);
            if (!result) return NotFound("Silinecek Tuvalet Bulunamadı.");
            return Ok("Tuvalet Başarıyla Silindi");
        }
    }
}
