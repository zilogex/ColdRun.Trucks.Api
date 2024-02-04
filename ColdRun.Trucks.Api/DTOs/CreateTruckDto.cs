using ColdRun.Trucks.Api.Enums;

namespace ColdRun.Trucks.Api.DTOs
{
    public class CreateTruckDto
    {
        public string TruckId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public TruckStatus? Status { get; set; }
    }
}
