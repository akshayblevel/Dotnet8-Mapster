using Dotnet8_Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VehicleDb>(opt => opt.UseInMemoryDatabase("VehicleList"));
MapsterConfig.Configure();
var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
