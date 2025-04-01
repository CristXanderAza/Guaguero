using Guaguero.API.Hubs;
using Guaguero.Application.DTOs.Travel;
using Guaguero.Application.Events.Travels;
using Microsoft.AspNetCore.SignalR;

namespace Guaguero.Application.NotifInterfaces
{
    public class TravelNotificator : ITravelNotificator
    {
        private readonly IHubContext<TravelHub> _hubContext;

        public TravelNotificator(IHubContext<TravelHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyArrivals(IEnumerable<ArrivalDTO> arrivals, string connectionID)
        {
            await _hubContext.Clients.Client(connectionID).SendAsync("NotifyArrivals", arrivals);
        }

        public async Task NotifyTravelChange(TravelLocationChangeNotification notification, string group)
        {
            await _hubContext.Clients.Group(group).SendAsync("NotifyTravelChange", notification);
        }

        public async Task SuscribeToTravel(Guid travelId, string userId)
        {
            string group = $"Linstiners::{travelId}";
            await _hubContext.Groups.AddToGroupAsync(userId, group);
            await _hubContext.Clients.Client(userId).SendAsync("SuscribeToTravel", $"Te uniste al viaje  {group}");
        }
    }
}
