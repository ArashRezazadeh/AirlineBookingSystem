// Services/Notification/Notification.Api/Program.cs
using Notification.Core.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using Notification.Core.Services;
using Notification.Infrastructure.Services;
using System.Reflection;
using Notification.Application.Handlers;
using MassTransit;
using Notification.Application.Consumers;
using BuildingBlocks.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<IDbConnection>(sp => 
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<INotificationService,NotificationService>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<PaymentProcessedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        var rabbitMqConfig = builder.Configuration.GetSection("RabbitMQ");
        cfg.Host(rabbitMqConfig["Host"], "/", h =>
        {
            h.Username(rabbitMqConfig["Username"]);
            h.Password(rabbitMqConfig["Password"]);
        });

        cfg.ReceiveEndpoint(EventBusConstants.PaymentProcessedQueue, e =>
        {
            e.ConfigureConsumer<PaymentProcessedConsumer>(context);
        });
    });
});


var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(SendNotificationCommandHandler).Assembly,
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();