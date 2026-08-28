using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningTracking.Business.DTO
{
    public class BuildingDTO
    {
        public int Id { get; set; }
        public string BuildingName { get; set; } = string.Empty;
    }

    public class CreateBuildingDTO
    {
        public string BuildingName { get; set; } = string.Empty;
    }

    public class UpdateBuildingDTO 
    {
        public int Id { get; set; }
        public string BuildingName { get; set;} = string.Empty;
    }
}
