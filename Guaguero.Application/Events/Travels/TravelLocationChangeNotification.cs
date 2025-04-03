using Guaguero.Application.NotifInterfaces;
using Guaguero.Domain.Entities.Logistic.Routes;
using MediatR;

namespace Guaguero.Application.Events.Travels
{
    public class TravelLocationChangeNotification : INotification
    {
        public Guid TravelID { get; set; }
        public Coordinate ActualLocation { get; set; }
        public int NextStep { get; set; }
        public string StepState { get; set; }
        public Coordinate WaypointLocation { get; set; }
        public string tiempoEstimado { get; set; }
    }

    public class TravelLocationChangeNotificationHandler : INotificationHandler<TravelLocationChangeNotification>
    {
        private readonly ITravelNotificator _travelNotificator;

        public TravelLocationChangeNotificationHandler(ITravelNotificator travelNotificator)
        {
            _travelNotificator = travelNotificator;
        }

        public async Task Handle(TravelLocationChangeNotification notification, CancellationToken cancellationToken)
        {
            string group = $"Linstiners::{notification.TravelID}";
            await _travelNotificator.NotifyTravelChange(notification, group);
        }
    }
}
