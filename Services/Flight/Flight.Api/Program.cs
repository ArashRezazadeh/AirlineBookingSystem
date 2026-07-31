// Services/Flight/Flight.Api/Program.cs (add for each service)
using Flight.Application.Handlers;
using Flight.Core.Repositories;
using Flight.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Dapper connection
builder.Services.AddScoped<IDbConnection>(sp => 
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<IFlightRepository, FlightRepository>();

var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(CreateFlightCommandHandler).Assembly,
    typeof(GetAllFlightsQueryHandler).Assembly,
    typeof(DeleteFlightCommandHandler).Assembly
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

var app = builder.Build();
 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();