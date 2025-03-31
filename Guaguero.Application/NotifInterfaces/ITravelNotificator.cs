using Guaguero.Application.DTOs.Travel;
using Guaguero.Application.Events.Travels;

namespace Guaguero.Application.NotifInterfaces
{
    public interface ITravelNotificator
    {
        Task SuscribeToTravel(Guid travelId, string connectionId);   
        Task NotifyTravelChange(TravelLocationChangeNotification notification, string group);
        Task NotifyArrivals(IEnumerable<ArrivalDTO> arrivals, string connectionID);
    }
}
