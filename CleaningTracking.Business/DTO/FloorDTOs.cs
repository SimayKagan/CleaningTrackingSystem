using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningTracking.Business.DTO
{
    public class FloorDTO
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int FloorNumber { get; set; }
    }

    public class CreateFloorDTO
    {
        public int BuildingId { get; set; }
        public int FloorNumber { get; set; }
    }
    public class UpdateFloorDTO
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int FloorNumber { get; set; }
    }
}

