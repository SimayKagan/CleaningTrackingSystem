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
    public class FloorManager : IFloorService
    {
        private readonly AppDbContext _context;
        public FloorManager(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<FloorDTO>> GetAllAsync()
        {
            return await _context.Floors.Select(f => new FloorDTO
            {
                Id = f.Id,
                BuildingId = f.BuildingId,
                FloorNumber = f.FloorNumber
            })
                .ToListAsync();
        }
        public async Task<FloorDTO?> GetByIdAsync(int id)
        {
            var floor = await _context.Floors.FindAsync(id);
            if (floor == null) return null;

            return new FloorDTO
            {
                Id = floor.Id,
                BuildingId = floor.BuildingId,
                FloorNumber = floor.FloorNumber
            };
        }
        public async Task<FloorDTO> CreateAsync(CreateFloorDTO dto)
        {
            var floor = new Floor
            {
                BuildingId = dto.BuildingId,
                FloorNumber = dto.FloorNumber
            };
            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();

            return new FloorDTO
            {
                Id = floor.Id,
                BuildingId = floor.BuildingId,
                FloorNumber = floor.FloorNumber
            };
        }
        public async Task<bool> UpdateAsync(UpdateFloorDTO dto)
        {
            var floor = await _context.Floors.FindAsync(dto.Id);
            if (floor == null) return false;
            floor.BuildingId = dto.BuildingId;
            floor.FloorNumber = dto.FloorNumber;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var floor = await _context.Floors.FindAsync(id);
            if (floor == null) return false;

            _context.Floors.Remove(floor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
