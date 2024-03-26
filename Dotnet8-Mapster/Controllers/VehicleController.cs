using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Dotnet8_Mapster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleDb _vehicleDb;

        public VehicleController(VehicleDb vehicleDb)
        {
            _vehicleDb = vehicleDb;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleDto>> Get()
        {
           var vehicles =  await _vehicleDb.Vehicles.ToListAsync();
           var response = vehicles.Adapt<List<VehicleDto>>();
           return response;
        }

        [HttpGet("{id}")]
        public async Task<VehicleDto> Get(int id)
        {
            var vehicle = await _vehicleDb.Vehicles.FindAsync(id);
            var response = vehicle.Adapt<VehicleDto>();
            return response;
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] VehicleDto vehicleDto)
        {
            var vehicle = vehicleDto.Adapt<Vehicle>();
            _vehicleDb.Vehicles.Add(vehicle);
            await _vehicleDb.SaveChangesAsync();
            return Results.Created($"/vehicles/{vehicle.Id}", vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] VehicleDto vehicleDto)
        {
            var veh = await _vehicleDb.Vehicles.FindAsync(id);
            if (veh == null) return Results.NotFound();

            veh.Name = vehicleDto.VehicleName;
            veh.IsComplete = vehicleDto.IsComplete;

            await _vehicleDb.SaveChangesAsync();
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            if (await _vehicleDb.Vehicles.FindAsync(id) is Vehicle vehicle)
            {
                _vehicleDb.Vehicles.Remove(vehicle);
                await _vehicleDb.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        }
    }
}
