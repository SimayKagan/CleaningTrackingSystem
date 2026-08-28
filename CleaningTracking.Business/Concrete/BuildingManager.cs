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

namespace CleaningTracking.Business.Concrete
{
    public class BuildingManager : IBuildingService
    {
        private readonly AppDbContext _context;
        public BuildingManager(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<BuildingDTO>> GetAllAsync()
        {
            return await _context.Buildings.Select(b => new BuildingDTO
            {
                Id = b.Id,
                BuildingName = b.BuildingName
            })
                .ToListAsync();
        }
        public async Task<BuildingDTO?> GetByIdAsync(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null) return null;

            return new BuildingDTO
            {
                Id = building.Id,
                BuildingName = building.BuildingName
            };
        }
        public async Task<BuildingDTO> CreateAsync(CreateBuildingDTO dto)
        {
            var building = new Building
            {
                BuildingName = dto.BuildingName
            };
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();

            return new BuildingDTO
            {
                Id = building.Id,
                BuildingName = building.BuildingName
            };
        }
        public async Task<bool> UpdateAsync(UpdateBuildingDTO dto)
        {
            var building = await _context.Buildings.FindAsync(dto.Id);
            if (building == null) return false;
            building.BuildingName = dto.BuildingName;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null) return false;

            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
