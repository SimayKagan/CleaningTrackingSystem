using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningTracking.Business.DTO
{
    public class RestroomDTO
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public string RestroomName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsClean { get; set; }
    }

    public class CreateRestroomDTO
    {
        public int FloorId { get; set; }
        public string RestroomName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class UpdateRestroomDTO
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public string RestroomName { get; set; } = String.Empty;
        public string? Description { get; set; }
        public bool IsClean { get; set; }
    }
}
