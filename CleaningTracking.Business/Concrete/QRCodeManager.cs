using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleaningTracking.Business.Abstract;
using CleaningTracking.Business.DTO;
using CleaningTracking.Core.Entities;
using CleaningTracking.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CleaningTracking.Business.Concrete
{
    public class QRCodeManager : IQRCodeService
    {
        private readonly AppDbContext _context;
        public QRCodeManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task<QRCodeDTO?> GetByRestroomIdAsync(int restroomId)
        {
            var qrCode = await _context.QRCodes.FirstOrDefaultAsync(q => q.RestroomId == restroomId);
            if (qrCode == null) return null;

            return new QRCodeDTO
            {
                Id = qrCode.Id,
                RestroomId = qrCode.RestroomId,
                QRCodeValue = qrCode.QRCodeValue,
                QRImagePath = qrCode.QRImagePath,
                CreatedDate = qrCode.CreatedDate
            };
        }
        public async Task<QRCodeDTO> CreateAsync(CreateQRCodeDTO dto)
        {
            var existingQRCode = await _context.QRCodes.AnyAsync(q => q.RestroomId == dto.RestroomId);
            if (existingQRCode)
            {
                throw new InvalidOperationException("Bu Tuvalet için zaten bir QR Kod oluşturulmuş.");
            }
            string qrCodeText = $"RESTROOM-{dto.RestroomId}-{Guid.NewGuid().ToString().Substring(0,8)}";
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
                BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
                byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);
                string fileName = $"qr_{dto.RestroomId}_{Guid.NewGuid().ToString().Substring(0, 5)}.png";
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "qrcodes");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                string fullPath = Path.Combine(folderPath, fileName);
                await File.WriteAllBytesAsync(fullPath, qrCodeAsPngByteArr);

                var qrCodeEntity = new CleaningTracking.Core.Entities.QRCode
                {
                    RestroomId = dto.RestroomId,
                    QRCodeValue = qrCodeText,
                    QRImagePath = $"/qrcodes/{fileName}",
                    CreatedDate = DateTime.UtcNow
                };

                _context.QRCodes.Add(qrCodeEntity);
                await _context.SaveChangesAsync();

                return new QRCodeDTO
                {
                    Id = qrCodeEntity.Id,
                    RestroomId = qrCodeEntity.RestroomId,
                    QRCodeValue = qrCodeEntity.QRCodeValue,
                    QRImagePath = qrCodeEntity.QRImagePath,
                    CreatedDate = qrCodeEntity.CreatedDate
                };
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var qrCode = await _context.QRCodes.FindAsync(id);
            if (qrCode == null) return false;

            _context.QRCodes.Remove(qrCode);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
