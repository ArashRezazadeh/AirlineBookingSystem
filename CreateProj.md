# Create solution
dotnet new sln -n FlightBookingSystem

# Create root folders
mkdir BuildingBlucks;mkdir Services
mkdir BuildingBlucks/Common; mkdir BuildingBlucks/Contracts

# Create service folders
mkdir Services/Flight ;mkdir Services/Booking ;mkdir Services/Payment ;mkdir Services/Notification

# Create project structure for each service
# Flight Service
mkdir Services/Flight/Flight.Api ;mkdir Services/Flight/Flight.Application ;mkdir Services/Flight/Flight.Core ;mkdir Services/Flight/Flight.Infrastructure
dotnet new webapi -n Flight.Api -o Services/Flight/Flight.Api
dotnet new classlib -n Flight.Application -o Services/Flight/Flight.Application
dotnet new classlib -n Flight.Core -o Services/Flight/Flight.Core
dotnet new classlib -n Flight.Infrastructure -o Services/Flight/Flight.Infrastructure

# Booking Service
mkdir Services/Booking/Booking.Api ;mkdir Services/Booking/Booking.Application ;mkdir Services/Booking/Booking.Core ;mkdir Services/Booking/Booking.Infrastructure
dotnet new webapi -n Booking.Api -o Services/Booking/Booking.Api
dotnet new classlib -n Booking.Application -o Services/Booking/Booking.Application
dotnet new classlib -n Booking.Core -o Services/Booking/Booking.Core
dotnet new classlib -n Booking.Infrastructure -o Services/Booking/Booking.Infrastructure

# Payment Service
mkdir Services/Payment/Payment.Api ;mkdir Services/Payment/Payment.Application ;mkdir Services/Payment/Payment.Core ;mkdir Services/Payment/Payment.Infrastructure
dotnet new webapi -n Payment.Api -o Services/Payment/Payment.Api
dotnet new classlib -n Payment.Application -o Services/Payment/Payment.Application
dotnet new classlib -n Payment.Core -o Services/Payment/Payment.Core
dotnet new classlib -n Payment.Infrastructure -o Services/Payment/Payment.Infrastructure

# Notification Service
mkdir Services/Notification/Notification.Api ;mkdir Services/Notification/Notification.Application ;mkdir Services/Notification/Notification.Core ;mkdir Services/Notification/Notification.Infrastructure
dotnet new webapi -n Notification.Api -o Services/Notification/Notification.Api
dotnet new classlib -n Notification.Application -o Services/Notification/Notification.Application
dotnet new classlib -n Notification.Core -o Services/Notification/Notification.Core
dotnet new classlib -n Notification.Infrastructure -o Services/Notification/Notification.Infrastructure

# Add projects to solution
dotnet sln add Services/Flight/Flight.Api/Flight.Api.csproj
dotnet sln add Services/Flight/Flight.Application/Flight.Application.csproj
dotnet sln add Services/Flight/Flight.Core/Flight.Core.csproj
dotnet sln add Services/Flight/Flight.Infrastructure/Flight.Infrastructure.csproj

dotnet sln add Services/Booking/Booking.Api/Booking.Api.csproj
dotnet sln add Services/Booking/Booking.Application/Booking.Application.csproj
dotnet sln add Services/Booking/Booking.Core/Booking.Core.csproj
dotnet sln add Services/Booking/Booking.Infrastructure/Booking.Infrastructure.csproj

dotnet sln add Services/Payment/Payment.Api/Payment.Api.csproj
dotnet sln add Services/Payment/Payment.Application/Payment.Application.csproj
dotnet sln add Services/Payment/Payment.Core/Payment.Core.csproj
dotnet sln add Services/Payment/Payment.Infrastructure/Payment.Infrastructure.csproj

dotnet sln add Services/Notification/Notification.Api/Notification.Api.csproj
dotnet sln add Services/Notification/Notification.Application/Notification.Application.csproj
dotnet sln add Services/Notification/Notification.Core/Notification.Core.csproj
dotnet sln add Services/Notification/Notification.Infrastructure/Notification.Infrastructure.csproj

# Add project references (Core -> no deps, Application -> Core, Infrastructure -> Core, Api -> Application + Infrastructure)
dotnet add Services/Flight/Flight.Application/Flight.Application.csproj reference Services/Flight/Flight.Core/Flight.Core.csproj
dotnet add Services/Flight/Flight.Infrastructure/Flight.Infrastructure.csproj reference Services/Flight/Flight.Core/Flight.Core.csproj
dotnet add Services/Flight/Flight.Api/Flight.Api.csproj reference Services/Flight/Flight.Application/Flight.Application.csproj
dotnet add Services/Flight/Flight.Api/Flight.Api.csproj reference Services/Flight/Flight.Infrastructure/Flight.Infrastructure.csproj

dotnet add Services/Booking/Booking.Application/Booking.Application.csproj reference Services/Booking/Booking.Core/Booking.Core.csproj
dotnet add Services/Booking/Booking.Infrastructure/Booking.Infrastructure.csproj reference Services/Booking/Booking.Core/Booking.Core.csproj
dotnet add Services/Booking/Booking.Api/Booking.Api.csproj reference Services/Booking/Booking.Application/Booking.Application.csproj
dotnet add Services/Booking/Booking.Api/Booking.Api.csproj reference Services/Booking/Booking.Infrastructure/Booking.Infrastructure.csproj

dotnet add Services/Payment/Payment.Application/Payment.Application.csproj reference Services/Payment/Payment.Core/Payment.Core.csproj
dotnet add Services/Payment/Payment.Infrastructure/Payment.Infrastructure.csproj reference Services/Payment/Payment.Core/Payment.Core.csproj
dotnet add Services/Payment/Payment.Api/Payment.Api.csproj reference Services/Payment/Payment.Application/Payment.Application.csproj
dotnet add Services/Payment/Payment.Api/Payment.Api.csproj reference Services/Payment/Payment.Infrastructure/Payment.Infrastructure.csproj

dotnet add Services/Notification/Notification.Application/Notification.Application.csproj reference Services/Notification/Notification.Core/Notification.Core.csproj
dotnet add Services/Notification/Notification.Infrastructure/Notification.Infrastructure.csproj reference Services/Notification/Notification.Core/Notification.Core.csproj
dotnet add Services/Notification/Notification.Api/Notification.Api.csproj reference Services/Notification/Notification.Application/Notification.Application.csproj
dotnet add Services/Notification/Notification.Api/Notification.Api.csproj reference Services/Notification/Notification.Infrastructure/Notification.Infrastructure.csproj

# Create Common and Contracts class libraries
dotnet new classlib -n Common -o BuildingBlucks/Common
dotnet new classlib -n Contracts -o BuildingBlucks/Contracts
dotnet sln add BuildingBlucks/Common/Common.csproj
dotnet sln add BuildingBlucks/Contracts/Contracts.csproj

# Add references to Common and Contracts for all services
dotnet add Services/Flight/Flight.Core/Flight.Core.csproj reference BuildingBlucks/Common/Common.csproj
dotnet add Services/Flight/Flight.Core/Flight.Core.csproj reference BuildingBlucks/Contracts/Contracts.csproj

dotnet add Services/Booking/Booking.Core/Booking.Core.csproj reference BuildingBlucks/Common/Common.csproj
dotnet add Services/Booking/Booking.Core/Booking.Core.csproj reference BuildingBlucks/Contracts/Contracts.csproj

dotnet add Services/Payment/Payment.Core/Payment.Core.csproj reference BuildingBlucks/Common/Common.csproj
dotnet add Services/Payment/Payment.Core/Payment.Core.csproj reference BuildingBlucks/Contracts/Contracts.csproj

dotnet add Services/Notification/Notification.Core/Notification.Core.csproj reference BuildingBlucks/Common/Common.csproj
dotnet add Services/Notification/Notification.Core/Notification.Core.csproj reference BuildingBlucks/Contracts/Contracts.csproj




mkdir Services\Flight\Flight.Core\Entities; mkdir Services\Booking\Booking.Core\Entities; mkdir Services\Payment\Payment.Core\Entities; mkdir Services\Notification\Notification.Core\Entities

mkdir Services\Flight\Flight.Core\Repositories; mkdir Services\Booking\Booking.Core\Repositories; mkdir Services\Payment\Payment.Core\Repositories; mkdir Services\Notification\Notification.Core\Repositories

mkdir Services\Flight\Flight.Infrastructure\Repositories; mkdir Services\Booking\Booking.Infrastructure\Repositories; mkdir Services\Payment\Payment.Infrastructure\Repositories; mkdir Services\Notification\Notification.Infrastructure\Repositories


# Install Dapper for all
dotnet add Services\Flight\Flight.Infrastructure\Flight.Infrastructure.csproj package Dapper; dotnet add Services\Flight\Flight.Infrastructure\Flight.Infrastructure.csproj package Microsoft.Data.SqlClient; dotnet add Services\Booking\Booking.Infrastructure\Booking.Infrastructure.csproj package Dapper; dotnet add Services\Booking\Booking.Infrastructure\Booking.Infrastructure.csproj package Microsoft.Data.SqlClient; dotnet add Services\Payment\Payment.Infrastructure\Payment.Infrastructure.csproj package Dapper; dotnet add Services\Payment\Payment.Infrastructure\Payment.Infrastructure.csproj package Microsoft.Data.SqlClient; dotnet add Services\Notification\Notification.Infrastructure\Notification.Infrastructure.csproj package Dapper; dotnet add Services\Notification\Notification.Infrastructure\Notification.Infrastructure.csproj package Microsoft.Data.SqlClient


# Create Command, Queries and Handlers folders
mkdir Services\Flight\Flight.Application\Commands; mkdir Services\Flight\Flight.Application\Handlers; mkdir Services\Flight\Flight.Application\Queries; mkdir Services\Booking\Booking.Application\Commands; mkdir Services\Booking\Booking.Application\Handlers; mkdir Services\Booking\Booking.Application\Queries; mkdir Services\Payment\Payment.Application\Commands; mkdir Services\Payment\Payment.Application\Handlers; mkdir Services\Payment\Payment.Application\Queries; mkdir Services\Notification\Notification.Application\Commands; mkdir Services\Notification\Notification.Application\Handlers; mkdir Services\Notification\Notification.Application\Queries 


# Install MediateR for all Application Layers 
dotnet add Services\Flight\Flight.Application\Flight.Application.csproj package MediatR; dotnet add Services\Booking\Booking.Application\Booking.Application.csproj package MediatR; dotnet add Services\Payment\Payment.Application\Payment.Application.csproj package MediatR; dotnet add Services\Notification\Notification.Application\Notification.Application.csproj package MediatR

# Install MediateR for all Api Layers 
dotnet add Services\Flight\Flight.Api\Flight.Api.csproj package MediatR; dotnet add Services\Booking\Booking.Api\Booking.Api.csproj package MediatR; dotnet add Services\Payment\Payment.Api\Payment.Api.csproj package MediatR; dotnet add Services\Notification\Notification.Api\Notification.Api.csproj package MediatR


# Update references from all services to point to new BuildingBlocks project
dotnet add Services\Flight\Flight.Core\Flight.Core.csproj reference BuildingBlocks\BuildingBlocks.csproj
dotnet add Services\Booking\Booking.Core\Booking.Core.csproj reference BuildingBlocks\BuildingBlocks.csproj
dotnet add Services\Payment\Payment.Core\Payment.Core.csproj reference BuildingBlocks\BuildingBlocks.csproj
dotnet add Services\Notification\Notification.Core\Notification.Core.csproj reference BuildingBlocks\BuildingBlocks.csproj

# Add MassTransit to all projects 
dotnet add Services\Flight\Flight.Api\Flight.Api.csproj package MassTransit; dotnet add Services\Flight\Flight.Api\Flight.Api.csproj package MassTransit.RabbitMQ; dotnet add Services\Booking\Booking.Api\Booking.Api.csproj package MassTransit; dotnet add Services\Booking\Booking.Api\Booking.Api.csproj package MassTransit.RabbitMQ; dotnet add Services\Payment\Payment.Api\Payment.Api.csproj package MassTransit; dotnet add Services\Payment\Payment.Api\Payment.Api.csproj package MassTransit.RabbitMQ; dotnet add Services\Notification\Notification.Api\Notification.Api.csproj package MassTransit; dotnet add Services\Notification\Notification.Api\Notification.Api.csproj package MassTransit.RabbitMQ

dotnet add Services\Payment\Payment.Application\Payment.Application.csproj package MassTransit; dotnet add Services\Payment\Payment.Application\Payment.Application.csproj package MassTransit.RabbitMQ;

dotnet add Services\Notification\Notification.Application\Notification.Application.csproj package MassTransit; dotnet add Services\Notification\Notification.Application\Notification.Application.csproj package MassTransit.RabbitMQ