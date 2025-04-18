﻿// See https://aka.ms/new-console-template for more information
using Guaguero.Application.Commands.Travels;
using Guaguero.Application.DTOs.Travel;
using Guaguero.Application.Events.Travels;
using Guaguero.Domain.Entities.Logistic.Routes;
using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7035/travelHub") // Cambia por la URL correcta
    .Build();

var methods = connection.GetType().GetMethods().Select(m => m.Name).ToList();
Console.WriteLine($"Métodos disponibles: {string.Join(", ", methods)}");

connection.ServerTimeout = TimeSpan.FromMinutes(5);

connection.On<string>("Error", message =>
{
    Console.WriteLine($"❌ Error recibido: {message}");
});

connection.On<TravelLocationChangeNotification>("NotifyTravelChange", notification =>
{
    Console.WriteLine($"📍 Cambio de ubicación: {notification.TravelID}: + {notification.ActualLocation}, Parada: {notification.NextStep}, Estado {notification.StepState} ");
});

Guid quotaId = Guid.NewGuid();
// 🔹 Confirmación de suscripción a un viaje
connection.On<string>("SuscribeToTravel", message =>
{
    Console.WriteLine($"✅ {message}");
});

connection.On<string>("QuotaReserved", message =>
{
    quotaId = new Guid(message);
    Console.WriteLine($"✅ {message}");
});

connection.On<ArrivalDTO>("ConfirmAcept", dto =>
{
    Console.WriteLine("Aceptaste tu cupo en " + dto.TravelID);
});

await connection.StartAsync();
Console.WriteLine("✅ Conectado al servidor de SignalR: Cliente");

while (true)
{
    Console.WriteLine("\n🔹 Opciones disponibles:");
    Console.WriteLine("1 - Crear Reserva");
    Console.WriteLine("2 - Actualizar Posición de Viaje");
    Console.WriteLine("3 - Confirmar Cupo");
    Console.WriteLine("4 - Confirmar Llegada");
    Console.WriteLine("5 - Iniciar Viaje");
    Console.WriteLine("0 - Salir");
    Console.Write("Selecciona una opción: ");

    string? input = Console.ReadLine();
    if (input == "0") break;

    switch (input)
    {
        case "1":
            await connection.InvokeAsync("CreateReser", new ReservQuotaCommand
            {
                TravelID = new Guid("F7C2A3D5-1B4E-4D19-8E2F-9F6A3C5B7D1E"),
                CustomerID = new Guid("A3F47C2B-1B3D-4E19-8E2A-3D9F7C5A1D5E"),
                EntryStep = 1,
                SeatsQuantity = 1,
                PaymentType = "Credit"
            });
            break;
        case "2":
            await connection.InvokeAsync("UpdateTravelPosition", new UpdateTravelPositionCommand { /* Datos */ });
            break;
        case "3":
            await connection.InvokeAsync("ConfirmQuota", new ConfirmQuotaCommand {
                QuotaID = quotaId,
                TravelID = new Guid("F7C2A3D5-1B4E-4D19-8E2F-9F6A3C5B7D1E"),
                
            });
            break;
        case "4":
            await connection.InvokeAsync("ConfirmArrivals", new ConfirmArrivalCommand { 
                ConfirmedArrivals = [new Guid("744B0BEE-B74C-4BFC-BFEF-08DD7238B9DD")],
                StepIndex = 1,
                TravelId = new Guid("F7C2A3D5-1B4E-4D19-8E2F-9F6A3C5B7D1E")

            });
            break;
        case "5":
            await connection.InvokeAsync("StartTravel", new StartTravelCommand
            {
                TravelId = new Guid("F7C2A3D5 - 1B4E - 4D19 - 8E2F - 9F6A3C5B7D1E"),
                EmpleoyeeID = new Guid("D5F1A8E7-4C6B-49F2-B7D9-65E3C7F9B2A1"),
                InformalArrivals = 12,
                StartLocation = new Coordinate(-69.543146, -69.501981)

            });
            break;
        default:
            Console.WriteLine("❌ Opción no válida.");
            break;
    }
}

await connection.StopAsync();
Console.WriteLine("🔴 Cliente desconectado.");
