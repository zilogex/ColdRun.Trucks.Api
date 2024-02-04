using ColdRun.Trucks.Api.Enums;

namespace ColdRun.Trucks.Api.Data.Models
{
    public class Truck
    {
        public string TruckId { get; set; }
        public string Name { get; set; } 
        public string? Description { get; set; }
        public TruckStatus Status { get; set; }
    }
}
