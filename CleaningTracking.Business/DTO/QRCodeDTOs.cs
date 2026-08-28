using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningTracking.Business.DTO
{
    public class QRCodeDTO
    {
        public int Id {  get; set; }
        public int RestroomId { get; set; }
        public string QRCodeValue { get; set; } = String.Empty;
        public string? QRImagePath {  get; set; }
        public DateTime CreatedDate {  get; set; }
    }

    public class CreateQRCodeDTO
    {
        public int RestroomId { get; set; }
    }
}
