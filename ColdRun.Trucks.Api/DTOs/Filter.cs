using ColdRun.Trucks.Api.Enums;

namespace ColdRun.Trucks.Api.DTOs
{
    public class FilterDto
    {
        public string? Filter { get; set; }
        public TruckStatus? Status { get; set; }
        public int? Ordered { get; set; }
    }
}
