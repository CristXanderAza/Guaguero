using Guaguero.Application.NotifInterfaces;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.Infraestructure.Internal;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels;
using Guaguero.Infraestructure.Internal.TravelCache;
using Guaguero.Persistence.Repositories.Travels;
using Microsoft.Extensions.DependencyInjection;

namespace Guaguero.InOC.Travels
{
    public static class TravelDependencies
    {
        public static void RegisterTravelDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITravelNotificator, TravelNotificator>();
            services.AddScoped<ITravelRepository, TravelRepository>();
            services.AddScoped<IQuotaRepository, QuotaRepository>();
            services.AddSingleton<IInMemoryCache<Travel, Guid>, TravelCache>();

            //services.AddScoped<INotificationHandler<TravelLocationChangeNotification>, TravelLocationChangeNotificationHandler>();
        }
    }
}
