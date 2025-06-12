using ColdRun.Trucks.Api.Data;
using ColdRun.Trucks.Api.Data.Models;
using ColdRun.Trucks.Api.DTOs;
using ColdRun.Trucks.Api.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColdRun.Trucks.Api.Controllers
{
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly Database db;

        public TruckController(Database db)
        {
            this.db = db;
        }

        [HttpPost("Trucks/Create")]
        public async Task<ActionResult<string>> CreateTruck([FromBody] CreateTruckDto truck)
        {
            if (await db.Trucks.AnyAsync(t => t.TruckId == truck.TruckId))
                return BadRequest();

            var entity = new Truck
            {
                TruckId = truck.TruckId,
                Name = truck.Name,
                Description = truck.Description ?? string.Empty,
                Status = truck.Status ?? TruckStatus.Loading,
            };
                
            await db.Trucks.AddAsync(entity);
            await db.SaveChangesAsync();

            return Ok();
        }



        [HttpPatch("Trucks/Update")]
        public async Task<ActionResult<string>> UpdateTruck([FromBody] TruckDto truck)
        {
            var entity = await db.Trucks.FindAsync(truck.TruckId);
            if (entity == null) return NotFound();



            entity.Name = truck.Name ?? entity.Name;
            entity.Description = truck.Description ?? entity.Description;
            entity.Status = truck.Status ?? entity.Status;

            db.Trucks.Update(entity);
            await db.SaveChangesAsync();
            return Ok(truck.TruckId);
        }


        [HttpGet("Trucks")]
        public async Task<ActionResult<List<Truck>>> ListTruck([FromQuery] string? filter, [FromQuery] TruckStatus? status, [FromQuery] int? ordered)
        {
            var filtered = db.Trucks.Where(t => t.TruckId.Contains(filter ?? string.Empty) ||
                                                t.Name.Contains(filter ?? string.Empty) ||
                                                t.Description == null || t.Description.Contains(filter ?? string.Empty));

            filtered = filtered.Where(t => !status.HasValue || t.Status == status);
            filtered = (ordered ?? 1) == 1 ? filtered.OrderBy(t => t.TruckId) : filtered.OrderByDescending(t => t.TruckId);

            return await filtered.ToListAsync();
        }

    }
}