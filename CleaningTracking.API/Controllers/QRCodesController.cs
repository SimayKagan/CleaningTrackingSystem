using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CleaningTracking.Business.Abstract;
using CleaningTracking.Business.DTO;

namespace CleaningTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodesController : ControllerBase
    {
        private readonly IQRCodeService _qrCodeService;
        public QRCodesController(IQRCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }

        [HttpGet("restroom/{restroomId}")]
        public async Task<IActionResult> GetByRestroomIdAsync(int restroomId)
        {
            var result = await _qrCodeService.GetByRestroomIdAsync(restroomId);
            if(result == null) return NotFound("Bu Alana Ait QR Kod Bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQRCodeDTO dto)
        {
            var result = await _qrCodeService.CreateAsync(dto);
            return Ok(new {Message = "QR Kod Başarıyla Oluşturuldu.", Data = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _qrCodeService.DeleteAsync(id);
            if (!result) return NotFound("Silinecek QR Kod Bulunamadı.");
            return Ok("QR Kod Başarıyla Silindi");
        }
    }
}
