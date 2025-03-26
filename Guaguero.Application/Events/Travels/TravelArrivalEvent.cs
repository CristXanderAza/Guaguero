using Guaguero.Application.DTOs.Travel;
using Guaguero.Application.NotifInterfaces;
using Guaguero.Domain.Entities.Travels;
using MediatR;

namespace Guaguero.Application.Events.Travels
{
    public class TravelArrivalEvent : INotification
    {
        public IEnumerable<Quota> Quotas { get; set; }
        public Guid TravelID { get; set; }
    }

    public class TravelArrivalEventHandler : INotificationHandler<TravelArrivalEvent>
    {
        private readonly ITravelNotificator _notificator;

        public TravelArrivalEventHandler(ITravelNotificator notificator)
        {
            _notificator = notificator;
        }

        public async Task Handle(TravelArrivalEvent notification, CancellationToken cancellationToken)
        {
            IEnumerable<ArrivalDTO> arrivals = notification.Quotas.Select(q => new ArrivalDTO
            {
                Id = q.QuotaID,
                seets = q.Quantity,
                TravelID = q.TravelID,
                Total = q.Total,
                IsPaid = q.Payment.Accepted
            });
            await _notificator.NotifyArrivals(arrivals, $"listeners::{notification.TravelID}");

        }
    }
}
