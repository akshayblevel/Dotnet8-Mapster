using Microsoft.EntityFrameworkCore;

namespace Dotnet8_Mapster
{
    public class VehicleDb : DbContext
    {
        public VehicleDb(DbContextOptions<VehicleDb> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
