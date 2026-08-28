using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningTracking.Core.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string BuildingName { get; set; } = String.Empty;
        public ICollection<Floor> Floors { get; set; } = new HashSet<Floor>();
    }
}
