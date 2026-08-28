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
    public class RestroomManager : IRestroomService
    {
        private readonly AppDbContext _context;
        public RestroomManager(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<RestroomDTO>> GetAllAsync()
        {
            return await _context.Restrooms.Select(r => new RestroomDTO
            {
                Id = r.Id,
                FloorId = r.FloorId,
                RestroomName = r.RestroomName,
                Description = r.Description,
                IsClean = r.IsClean
            })
                .ToListAsync();
        }
        public async Task<RestroomDTO?> GetByIdAsync(int id)
        {
            var restroom = await _context.Restrooms.FindAsync(id);
            if (restroom == null) return null;

            return new RestroomDTO
            {
                Id = restroom.Id,
                FloorId = restroom.FloorId,
                RestroomName = restroom.RestroomName,
                Description = restroom.Description,
                IsClean = restroom.IsClean
            };
        }
        public async Task<RestroomDTO> CreateAsync(CreateRestroomDTO dto)
        {
            var restroom = new Restroom
            {
                FloorId = dto.FloorId,
                RestroomName = dto.RestroomName,
                Description = dto.Description,
                IsClean = false
            };
            _context.Restrooms.Add(restroom);
            await _context.SaveChangesAsync();

            return new RestroomDTO
            {
                Id = restroom.Id,
                FloorId = restroom.FloorId,
                RestroomName = restroom.RestroomName,
                Description = restroom.Description,
                IsClean = restroom.IsClean
            };
        }
        public async Task<bool> UpdateAsync(UpdateRestroomDTO dto)
        {
            var restroom = await _context.Restrooms.FindAsync(dto.Id);
            if (restroom == null) return false;
            restroom.FloorId = dto.FloorId;
            restroom.RestroomName = dto.RestroomName;
            restroom.Description = dto.Description;
            restroom.IsClean = dto.IsClean;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var restroom = await _context.Restrooms.FindAsync(id);
            if (restroom == null) return false;

            _context.Restrooms.Remove(restroom);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
