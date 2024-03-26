using Mapster;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Dotnet8_Mapster
{
    public static class MapsterConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<Vehicle, VehicleDto>.NewConfig()
                .Map(dest => dest.VehicleId, src => src.Id)
                .Map(dest => dest.VehicleName, src => src.Name)
                .Map(dest => dest.IsComplete, src => src.IsComplete);

            TypeAdapterConfig<VehicleDto, Vehicle>.NewConfig()
                .Map(dest => dest.Id, src => src.VehicleId)
                .Map(dest => dest.Name, src => src.VehicleName)
                .Map(dest => dest.IsComplete, src => src.IsComplete);
        }
    }
}
