// Services/Booking/Booking.Api/Program.cs

using Booking.Core.Repositories;
using Booking.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

using System.Reflection;
using Booking.Application.Handlers;
using MassTransit;
using Booking.Application.Consumers;
using BuildingBlocks.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IDbConnection>(sp => 
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<NotificationEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        var rabbitMqConfig = builder.Configuration.GetSection("RabbitMQ");
        cfg.Host(rabbitMqConfig["Host"], "/", h =>
        {
            h.Username(rabbitMqConfig["Username"]);
            h.Password(rabbitMqConfig["Password"]);
        });

        cfg.ReceiveEndpoint(EventBusConstants.NotificationSentQueue, e =>
        {
            e.ConfigureConsumer<NotificationEventConsumer>(context);
        });
    }); 
});

var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(CreateBookingCommandHandler).Assembly,
    typeof(GetBookingQueryHandler).Assembly
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();