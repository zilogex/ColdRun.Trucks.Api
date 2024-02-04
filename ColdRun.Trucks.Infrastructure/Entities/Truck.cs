using ColdRun.Trucks.Infrastructure.Enums;

namespace ColdRun.Trucks.Infrastructure.Entities
{
    public class Truck
    {
        public string TruckId { get; set; }
        public string Description { get; set; }
        public TruckStatus Status { get; set; }
    }
}
