using Guaguero.Application.Commands.Travels;
using Guaguero.Application.DTOs.Travel;
using Guaguero.Application.Events.Travels;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Guaguero.API.Hubs
{
    public class TravelHub : Hub
    {
        private readonly IMediator _mediator;

        public TravelHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Join Travel Group
        public async Task SuscribeToTravel(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.Caller.SendAsync("SuscribeToTravel", $"Te uniste al viaje  {group}");
        }

        //Commands
        public async Task CreateReser(ReservQuotaCommand command)
        {
            command.ConnectionID = Context.ConnectionId;
            var res = await _mediator.Send(command);
            if (!res.IsSuccessful)
            {
                await Clients.Caller.SendAsync("Error", res.Message);
            }
        }

        public async Task UpdateTravelPosition(UpdateTravelPositionCommand command)
        {
            command.ConnectionID = Context.ConnectionId;
            var res = await _mediator.Send(command);
            if (!res.IsSuccessful)
            {
                await Clients.Caller.SendAsync("Error", res.Message);
            }
        }

        public async Task ConfirmQuota(ConfirmQuotaCommand command)
        {

            var res = await _mediator.Send(command);
            if (!res.IsSuccessful)
            {
                await Clients.Caller.SendAsync("Error", res.Message);
            }
        }

        public async Task ConfirmArrivals(ConfirmArrivalCommand command)
        {

            var res = await _mediator.Send(command);
            if (!res.IsSuccessful)
            {
                await Clients.Caller.SendAsync("Error", res.Message);
            }
        }

        public async Task StartTravel(StartTravelCommand command)
        {

            var res = await _mediator.Send(command);
            if (!res.IsSuccessful)
            {
               await Clients.Caller.SendAsync("Error", res.Message);
            }
        }

        //Events
        public async Task NotifyTravelChange(TravelLocationChangeNotification notification, string group)
            =>  await Clients.Group(group).SendAsync("NotifyTravelChange", notification);
        public async Task NotifyArrivals(IEnumerable<ArrivalDTO> arrivals)
            => await Clients.Caller.SendAsync("NotifyArrivals", arrivals);
        

    }
}
