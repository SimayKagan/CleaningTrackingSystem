using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningTracking.Core.Entities
{
    public class QRCode
    {
        public int Id { get; set; }
        public int RestroomId { get; set; }
        public string QRCodeValue { get; set; } = "";
        public string? QRImagePath { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Restroom Restroom { get; set; } = null!;
    }
}
