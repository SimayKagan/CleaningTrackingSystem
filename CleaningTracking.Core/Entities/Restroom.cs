using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningTracking.Core.Entities
{
    public class Restroom
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public string RestroomName { get; set; } = "";
        public string? Description { get; set; }
        public bool IsClean { get; set; } = false;

        public Floor Floor { get; set; } = null!;
        public QRCode? QRCode { get; set; }
    }
}
