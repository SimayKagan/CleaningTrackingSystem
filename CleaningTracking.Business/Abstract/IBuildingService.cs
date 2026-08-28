using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleaningTracking.Business.DTO;

namespace CleaningTracking.Business.Abstract
{
    public interface IBuildingService
    {
        Task<List<BuildingDTO>> GetAllAsync();
        Task<BuildingDTO?> GetByIdAsync(int id);
        Task<BuildingDTO> CreateAsync(CreateBuildingDTO dto);
        Task<bool> UpdateAsync(UpdateBuildingDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
