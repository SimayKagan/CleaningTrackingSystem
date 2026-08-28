using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleaningTracking.Business.DTO;
namespace CleaningTracking.Business.Abstract
{
    public interface IRestroomService
    {
        Task<List<RestroomDTO>> GetAllAsync();
        Task<RestroomDTO?> GetByIdAsync(int id);
        Task<RestroomDTO> CreateAsync(CreateRestroomDTO dto);
        Task<bool> UpdateAsync(UpdateRestroomDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
