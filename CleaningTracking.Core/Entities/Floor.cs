using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningTracking.Core.Entities
{
    public class Floor
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int FloorNumber { get; set; }

        public Building Building { get; set; } = null!;
        public ICollection<Restroom> Restrooms { get; set; } = new HashSet<Restroom>();
    }
}
