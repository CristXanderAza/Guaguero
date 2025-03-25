

namespace Guaguero.Domain.Interfaces.Infraestructure.Internal
{
    public interface ITravelNotificator
    {
        Task SuscribeToTravel(Guid travelId);   
    }
}
