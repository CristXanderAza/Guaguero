using Guaguero.Application.NotifInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Guaguero.InOC.Travel
{
    public static class TravelDependencies
    {
        public static void RegisterTravelDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITravelNotificator, TravelNotificator>();
            
            //services.AddScoped<INotificationHandler<TravelLocationChangeNotification>, TravelLocationChangeNotificationHandler>();
        }
    }
}
