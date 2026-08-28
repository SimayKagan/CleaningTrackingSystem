using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleaningTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace CleaningTracking.DataAccess.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }
        public DbSet<Building> Buildings { get; set; } = null!;
        public DbSet<Floor> Floors { get; set; } = null!;
        public DbSet<Restroom> Restrooms { get; set; } = null!;
        public DbSet<QRCode> QRCodes { get; set; } = null!;
    }
}
