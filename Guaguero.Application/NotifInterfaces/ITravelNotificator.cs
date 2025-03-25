using Guaguero.Application.Events.Travels;

namespace Guaguero.Application.NotifInterfaces
{
    public interface ITravelNotificator
    {
        Task SuscribeToTravel(Guid travelId, Guid userId);   
        Task NotifyTravelChange(TravelLocationChangeNotification notification, string group);
    }
}
