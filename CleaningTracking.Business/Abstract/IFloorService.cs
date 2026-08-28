using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleaningTracking.Business.DTO;
namespace CleaningTracking.Business.Abstract
{
    public interface IFloorService
    {
        Task<List<FloorDTO>> GetAllAsync();
        Task<FloorDTO?> GetByIdAsync(int id);
        Task<FloorDTO> CreateAsync(CreateFloorDTO dto);
        Task<bool> UpdateAsync(UpdateFloorDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
