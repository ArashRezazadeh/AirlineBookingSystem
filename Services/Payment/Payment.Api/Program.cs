// Services/Payment/Payment.Api/Program.cs
using Payment.Core.Repositories;
using Payment.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using Payment.Application.Handlers;
using MassTransit;
using Payment.Application.Consumers;
using BuildingBlocks.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IDbConnection>(sp => 
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<BookingCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        var rabbitMqConfig = builder.Configuration.GetSection("RabbitMQ");
        cfg.Host(rabbitMqConfig["Host"], "/", h =>
        {
            h.Username(rabbitMqConfig["Username"]);
            h.Password(rabbitMqConfig["Password"]);
        });

        cfg.ReceiveEndpoint(EventBusConstants.BookingCreatedQueue, e =>
        {
            e.ConfigureConsumer<BookingCreatedConsumer>(context);
        });
    });
});

var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(ProcessPaymentCommandHandler).Assembly,
    typeof(RefundPaymentCommandHandler).Assembly
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

var app = builder.Build();



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();