using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleaningTracking.Business.DTO;
namespace CleaningTracking.Business.Abstract
{
     public interface IQRCodeService
    {
        Task<QRCodeDTO?> GetByRestroomIdAsync(int restroomId);
        Task<QRCodeDTO> CreateAsync(CreateQRCodeDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
