using CXAD.NetStrategist;
using Guaguero.Application.Commands.Travels.PaymentStrategies;
using Guaguero.Domain.Entities.Travels;
using Guaguero.Domain.Interfaces.Infraestructure.Internal;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Travels;
using Guaguero.Domain.Interfaces.PersistenceInterfaces.Users;
using Guaguero.Infraestructure.Internal.TravelCache;
using Guaguero.Persistence.Repositories.Travels;
using Guaguero.Persistence.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

namespace Guaguero.InOC.Travels
{
    public static class TravelDependencies
    {
        public static void RegisterTravelDependencies(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ITravelRepository, TravelRepository>();
            services.AddScoped<IQuotaRepository, QuotaRepository>();
            services.AddScoped<IStrategistFor<IPayStrategy, string>, PaymentStrategiest>();
            services.AddScoped<CreditPayStrategy>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IInMemoryCache<Travel, Guid>, TravelCache>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Guaguero.Application.AssemblyReference.Assembly));
            //services.AddScoped<INotificationHandler<TravelLocationChangeNotification>, TravelLocationChangeNotificationHandler>();
        }
    }
}
