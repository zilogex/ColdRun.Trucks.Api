using ColdRun.Trucks.Api.Enums;

namespace ColdRun.Trucks.Api.DTOs
{
    public class TruckDto
    {
        public string TruckId { get; set; }
        public string? Name { get; set;}
        public string? Description { get; set; }
        public TruckStatus? Status { get; set; }
    }
}
